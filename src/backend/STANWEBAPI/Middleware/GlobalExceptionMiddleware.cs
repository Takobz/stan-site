using System.Text.Json;
using STANWEBAPI.Constants;
using STANWEBAPI.Exceptions;
using STANWEBAPI.Models.DTOs.Responses;

namespace STANWEBAPI.Middleware
{
    public class GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger
    )
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (ApplicationHttpException exception)
            {
                await WriteErrorResponse(
                    httpContext,
                    exception.ErrorMessage,
                    exception.Errors,
                    exception.StatusCode
                );
            }
            catch (Exception exception)
            {
                logger.LogError(
                    exception,
                    "Unexpected Exception happened with message: {ExceptionMessage}",
                    exception.Message
                );

                await WriteErrorResponse(
                    httpContext,
                    ApplicationErrorMessages.GenericMessage,
                    ["Unexpected Error Occurred"]
                );
            }
        }

        private static async Task WriteErrorResponse(
            HttpContext context,
            string errorMessage,
            string[] errors,
            int statusCode = 500
        )
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(
                new BaseResponse<EmptyData>(
                    errorMessage,
                    errors
                ),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                }
            );
        }
    }
}