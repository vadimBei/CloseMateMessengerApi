using System.Net;
using Utils.Constants;

namespace Utils.Exceptions
{
    public abstract class CustomException : Exception
    {
        public HttpStatusCode Code { get; private set; }

        public string ErrorMessage { get; private set; }

        public string ErrorType { get; private set; }

        public CustomException(HttpStatusCode code, string errorMessage, string errorType)
        {
            Code = code;
            ErrorMessage = string.IsNullOrEmpty(errorMessage) ? "Custom exception" : errorMessage;
            ErrorType = string.IsNullOrEmpty(errorType) ? BaseErrorType.InternalError : errorType.ToUpper();
        }
    }
}
