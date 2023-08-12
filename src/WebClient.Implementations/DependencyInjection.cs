using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebClient.Implementations.Options;
using WebClient.Implementations.Services;
using WebClient.Interfaces.Interfaces;

namespace WebClient.Implementations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebClient(this IServiceCollection services, IConfiguration configuration)
        {
            // register options
            services.Configure<WebResourcesOptions>(configuration.GetSection("WebResources"));

            // add context accessor
            services.AddHttpContextAccessor();

            services.AddHttpClient();
            services.AddHttpClient("no-ssl-validation")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback =
                            (httpRequestMessage, cert, certChain, policyErrors) => true
                    };
                });

            // register web client services
            services.AddTransient<IWebClient, WebClientService>();

            return services;
        }
    }
}
