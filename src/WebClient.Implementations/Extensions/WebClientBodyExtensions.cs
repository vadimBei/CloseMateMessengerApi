using Newtonsoft.Json;
using System.Text;
using WebClient.Interfaces.Interfaces;

namespace WebClient.Implementations.Extensions
{
    public static class WebClientBodyExtensions
    {
        public static IWebClient WithStringContent(this IWebClient webClient, string bodyContent)
        {
            var data = new StringContent(bodyContent, Encoding.UTF8, "application/json");

            webClient.Configuration.HttpContent = data;

            return webClient;
        }

        public static IWebClient WithStringContent(this IWebClient webClient, object bodyContentObject)
        {
            var json = JsonConvert.SerializeObject(bodyContentObject);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            webClient.Configuration.HttpContent = data;

            return webClient;
        }
    }
}
