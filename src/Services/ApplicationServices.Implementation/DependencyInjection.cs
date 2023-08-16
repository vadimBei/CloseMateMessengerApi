using ApplicationServices.Implementation.Services;
using ApplicationServices.Interfaces.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationServices.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IChatMessageService, ChatMessageService>();

            return services;
        }
    }
}
