using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EquipTrack.Api.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        /// <inheritdoc/>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An error occurred");

            var details = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Server error",
                Detail = "An unexpected error occurred."
            };

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
        }
    }
}