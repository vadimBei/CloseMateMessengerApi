using System.Net;
using Utils.Constants;
using Utils.Exceptions;

namespace WebClient.Implementations.Exceptions
{
    public class WebResourceException : CustomException
    {
        public WebResourceException(HttpStatusCode code, string errorMessage) 
            : base(code, errorMessage, BaseErrorType.WebClientError)
        {
        }
    }
}
