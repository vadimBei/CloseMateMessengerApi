using System.Net;
using Utils.Constants;
using Utils.Exceptions;

namespace WebClient.Implementations.Exceptions
{
    public class WebClientNotFoundException : CustomException
    {
        public WebClientNotFoundException()
            : base(HttpStatusCode.NotFound, "Not found exception", BaseErrorType.WebClientError)
        {

        }

        public WebClientNotFoundException(string message)
            : base(HttpStatusCode.NotFound, message, BaseErrorType.WebClientError)
        {
        }
    }
}
