using Newtonsoft.Json;
using System.Net;
using Utils.Constants;
using Utils.Exceptions;
using WebClient.Implementations.Enums;
using WebClient.Implementations.Exceptions;

namespace WebClient.Implementations.Helpers
{
    public static class ErrorHandlerHelper
    {
        public static object HandleError(HttpResponseMessage responseMessage, string responseData, ErrorHandlingMode handlingMode)
        {
            switch (handlingMode)
            {
                case ErrorHandlingMode.Ignore:
                    return null;
                case ErrorHandlingMode.Manual:
                    throw new WebClientException(responseMessage.StatusCode, string.IsNullOrEmpty(responseData) ? string.Empty : responseData);
                case ErrorHandlingMode.Auto:
                    return GetAutoException(responseMessage.StatusCode, responseData);
                case ErrorHandlingMode.Debug:
                    throw new WebClientException(responseMessage.StatusCode, $"{JsonConvert.SerializeObject(responseMessage)}");
                default:
                    throw new WebClientException(responseMessage.StatusCode, responseData);
            }
        }

        private static object GetAutoException(HttpStatusCode code, string message)
        {
            switch (code)
            {
                case HttpStatusCode.NotFound:
                    var exceptionNotFound = JsonConvert.DeserializeObject<NotFoundException>(message);
                    throw (exceptionNotFound.ErrorType == BaseErrorType.NotFoundError)
                        ? exceptionNotFound
                        : new WebClientException(code, message);

                case HttpStatusCode.UnprocessableEntity:
                    var exceptionUnprocessableEntity = JsonConvert.DeserializeObject<ValidationException>(message);
                    throw (exceptionUnprocessableEntity.ErrorType == BaseErrorType.ValidationError)
                        ? exceptionUnprocessableEntity
                        : new WebClientException(code, message);

                default:
                    throw new WebClientException(code, message);
            }
        }
    }
}
