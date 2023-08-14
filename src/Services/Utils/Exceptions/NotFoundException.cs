using System.Net;
using Utils.Constants;

namespace Utils.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException()
            : base(HttpStatusCode.NotFound, "Not found exception", BaseErrorType.NotFoundError)
        {

        }

        public NotFoundException(string message)
            : base(HttpStatusCode.NotFound, message, BaseErrorType.NotFoundError)
        {
        }

        public NotFoundException(Type type, object entityId)
            : base(HttpStatusCode.NotFound, $"Entity '{type.Name}' was not found with Id: {entityId}", BaseErrorType.NotFoundError)
        {
        }
    }
}
