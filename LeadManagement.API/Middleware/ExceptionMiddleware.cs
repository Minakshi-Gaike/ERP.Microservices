using Microsoft.Data.SqlClient;
using System.Net;

namespace LeadManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            // 409 - Duplicate record
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                _logger.LogWarning(
                    ex,
                    "Duplicate record detected while processing {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                context.Response.StatusCode =
                    (int)HttpStatusCode.Conflict;

                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = 409,
                    Message = "A record with the same value already exists."
                };

                await context.Response.WriteAsJsonAsync(response);
            }

            // 400 - Validation error
            catch (ArgumentException ex)
            {
                _logger.LogWarning(
                    ex,
                    "Validation error while processing {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                context.Response.StatusCode =
                    (int)HttpStatusCode.BadRequest;

                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = 400,
                    Message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }

            // 500 - Unexpected error
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Unhandled exception occurred while processing {Method} {Path}",
                    context.Request.Method,
                    context.Request.Path);

                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = 500,
                    Message = "An unexpected error occurred."
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}