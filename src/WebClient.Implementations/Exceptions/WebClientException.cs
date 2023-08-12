using System.Net;
using Utils.Constants;
using Utils.Exceptions;

namespace WebClient.Implementations.Exceptions
{
    public class WebClientException : CustomException
    {
        public WebClientException(HttpStatusCode code, string errorMessage)
            : base(code, errorMessage, BaseErrorType.WebClientError)
        {
        }
    }
}
