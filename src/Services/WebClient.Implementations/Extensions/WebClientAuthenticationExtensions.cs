using System.Net;
using System.Net.Http.Headers;
using WebClient.Abstractions.Interfaces;
using WebClient.Implementations.Exceptions;
using WebClient.Implementations.Helpers;

namespace WebClient.Implementations.Extensions
{
    public static class IWebClientAuthenticationExtensions
    {
        /// <summary>
        /// Add basic authentication header from selected WebResource section
        /// </summary>
        public static IWebClient WithBasicAuthentication(this IWebClient webClient)
        {
            if (webClient.Configuration.Segment == null)
                throw new WebResourceException(HttpStatusCode.NotFound, "WebResource segment not specified");

            if (webClient.Configuration.Segment.Login != null)
            {
                var authHeader = new AuthenticationHeaderValue("Basic",
                    AuthHelper.GetBasicAuthToken(webClient.Configuration.Segment.Login, webClient.Configuration.Segment.Password));

                webClient.HttpClient.DefaultRequestHeaders.Authorization = authHeader;
            }

            return webClient;
        }

        /// <summary>
        /// Add basic authentication header with login and password
        /// </summary>
        public static IWebClient WithBasicAuthentication(this IWebClient webClient, string login, string password)
        {
            var authHeader = new AuthenticationHeaderValue("Basic", AuthHelper.GetBasicAuthToken(login, password));

            webClient.HttpClient.DefaultRequestHeaders.Authorization = authHeader;

            return webClient;
        }

        /// <summary>
        /// Add basic authentication header with token
        /// </summary>
        public static IWebClient WithBasicAuthentication(this IWebClient webClient, string token)
        {
            var authHeader = new AuthenticationHeaderValue("Basic", token);

            webClient.HttpClient.DefaultRequestHeaders.Authorization = authHeader;

            return webClient;
        }

        /// <summary>
        /// Add pass-through authentication JWT header
        /// </summary>
        public static IWebClient WithBearerAuthentication(this IWebClient webClient)
        {
            var token = webClient.Configuration.HttpContext?.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(token))
                throw new AuthorizationException(HttpStatusCode.Unauthorized, "Bearer authorization token not found in request");

            token = token.Replace("Bearer", "");

            var authHeader = new AuthenticationHeaderValue("Bearer", token.Trim());

            webClient.HttpClient.DefaultRequestHeaders.Authorization = authHeader;

            return webClient;
        }

        /// <summary>
        /// Add authentication Bearer JWT header
        /// </summary>
        public static IWebClient WithBearerAuthentication(this IWebClient webClient, string token)
        {
            var authHeader = new AuthenticationHeaderValue("Bearer", token);

            webClient.HttpClient.DefaultRequestHeaders.Authorization = authHeader;

            return webClient;
        }
    }
}
