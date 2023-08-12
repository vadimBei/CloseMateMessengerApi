using Newtonsoft.Json;
using System.Net;
using Utils.Constants;
using Utils.Exceptions;

namespace CloseMate.Api.Extensions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException customException)
            {
                context.Response.StatusCode = (int)customException.Code;

                var errorResponse = new
                {
                    StatusCode = customException.Code,
                    Message = customException.ErrorMessage,
                    ErrorType = customException.ErrorType
                };

                var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var errorResponse = new
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    ErrorType = BaseErrorType.InternalError
                };

                var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
