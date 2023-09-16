using System.Collections.Specialized;
using System.Web;
using WebClient.Abstractions.Interfaces;

namespace WebClient.Implementations.Extensions
{
    public static class WebClientQueryExtensions
    {
        /// <summary>
        /// Add params to query uri
        /// </summary>
        /// <param name="queryParams">Parameters object - new { key = value}</param>
        public static IWebClient WithQueryParams(this IWebClient webClient, object queryParams)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            if (queryParams != null)
            {
                if (queryParams is NameValueCollection)
                {
                    var query = queryParams as NameValueCollection;

                    var keyValuePair = query.AllKeys.SelectMany(query.GetValues, (key, value) => new { key = key, value = value });

                    foreach (var pair in keyValuePair)
                        if (pair.value != null)
                            queryString.Add(pair.key, pair.value);

                    return webClient;
                }

                foreach (var property in queryParams.GetType().GetProperties())
                {
                    var propertyValue = property.GetValue(queryParams, null);
                    if (propertyValue == null)
                        continue;
                    queryString.Add(property.Name, property.GetValue(queryParams).ToString());
                }
            }

            webClient.Configuration.QueryString = "?" + queryString.ToString();

            return webClient;
        }

        /// <summary>
        /// Add params string to query uri
        /// </summary>
        /// <param name="queryParamsString">Query params. Start with '?', like ?key=value</param>
        public static IWebClient WithQueryParams(this IWebClient webClient, string queryParamsString)
        {
            webClient.Configuration.QueryString = queryParamsString;

            return webClient;
        }
    }
}
