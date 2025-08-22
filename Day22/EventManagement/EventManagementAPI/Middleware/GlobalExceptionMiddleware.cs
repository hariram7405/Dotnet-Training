using EventManagement.Core.DTOs;
using EventManagement.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace EventManagementAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            var response = new ErroResponseDTO
            {
                Timestamp = DateTime.UtcNow
            };

            switch (exception)
            {
                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Resource not found";
                    response.Details = exception.Message;
                    break;
                case ValidationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Validation failed";
                    response.Details = exception.Message;
                    break;
                case DuplicateRegistrationException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = "Duplicate registration";
                    response.Details = exception.Message;
                    break;
                case DuplicateUserException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = "Duplicate user";
                    response.Details = exception.Message;
                    break;
                case DuplicateEventException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = "Duplicate event";
                    response.Details = exception.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An error occurred while processing your request";
                    response.Details = exception.Message;
                    break;
            }

            context.Response.StatusCode = response.StatusCode;
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
