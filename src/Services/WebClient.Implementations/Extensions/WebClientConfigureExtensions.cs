using System.Net;
using Utils.Exceptions;
using WebClient.Abstractions.Enums;
using WebClient.Abstractions.Interfaces;
using WebClient.Abstractions.Options;
using WebClient.Implementations.Exceptions;

namespace WebClient.Implementations.Extensions
{
    public static class WebClientConfigureExtensions
    {
        public static IWebClient Configure(this IWebClient webClient, Action<IWebClientConfiguration> baseConfiguration)
        {
            var configuration = new WebClientConfiguration();
            baseConfiguration.Invoke(configuration);

            if (!string.IsNullOrEmpty(configuration.WebResourcePath))
                webClient.WithWebResource(configuration.WebResourcePath);

            if (!string.IsNullOrEmpty(configuration.RequestUri))
                webClient.WithUri(configuration.RequestUri);

            webClient.Configuration.AuthenticationType = configuration.AuthenticationType;

            switch (webClient.Configuration.AuthenticationType)
            {
                case AuthenticationType.Basic:
                    webClient.WithBasicAuthentication();
                    break;

                case AuthenticationType.Bearer:
                    webClient.WithBearerAuthentication();
                    break;
            }

            return webClient;
        }

        public static IWebClient WithWebResource(this IWebClient webClient, string webResourcePath)
        {
            var engine = webClient as IWebClientEngine;
            engine.SetWebResource(webResourcePath);

            return webClient;
        }

        public static IWebClient WithWebResource(this IWebClient webClient, WebResource webResource)
        {
            var segment = webResource.Segments.FirstOrDefault();

            webClient.Configuration.WebResource = webResource ??
                throw new WebResourceException(HttpStatusCode.ServiceUnavailable, $"Resource not found in resources collection");

            webClient.Configuration.Segment = segment ??
                throw new WebResourceException(HttpStatusCode.ServiceUnavailable, $"No segment in resource {webResource.Name} segments collection");

            webClient.Configuration.RequestUri = webClient.Configuration.WebResource.Host + webClient.Configuration.Segment.Url;

            return webClient;
        }

        public static IWebClient WithUri(this IWebClient webClient, string uri)
        {
            webClient.Configuration.WebResource = null;
            webClient.Configuration.Segment = null;
            webClient.Configuration.WebResourcePath = string.Empty;

            webClient.Configuration.RequestUri = uri;

            return webClient;
        }
    }
}
