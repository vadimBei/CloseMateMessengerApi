using System.Net;
using Utils.Constants;
using Utils.Exceptions;

namespace Entities.Exceptions
{
    public class EntityNotFoundException : CustomException
    {
        public EntityNotFoundException()
            : base(HttpStatusCode.NotFound, "Not found exception", BaseErrorType.NotFoundError)
        {

        }

        public EntityNotFoundException(string message)
            : base(HttpStatusCode.NotFound, message, BaseErrorType.NotFoundError)
        {
        }

        public EntityNotFoundException(Type type, object entityId)
            : base(HttpStatusCode.NotFound, $"Entity '{type.Name}' was not found with Id: {entityId}", BaseErrorType.NotFoundError)
        {
        }
    }
}
