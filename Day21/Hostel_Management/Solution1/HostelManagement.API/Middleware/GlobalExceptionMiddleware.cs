using HostelManagement.Core.DTOs;
using HostelManagement.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HostelManagement.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, context.TraceIdentifier);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string correlationId)
        {
            context.Response.ContentType = "application/json";

            int statusCode;
            string message;
            string? detail = null;

            switch (exception)
            {
                case NotFoundException nf:
                    statusCode = StatusCodes.Status404NotFound;
                    message = nf.Message;
                    detail = _env.IsDevelopment() ? nf.StackTrace : null;
                    break;

                case ValidationException ve:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = ve.Message;
                    detail = _env.IsDevelopment() ? ve.StackTrace : null;
                    break;

                case RoomFullException or RoomHasStudentsException or
                     StaffOverloadException or StaffHasStudentsException or
                     DeleteOperationException:
                    statusCode = StatusCodes.Status409Conflict;
                    message = exception.Message;
                    detail = _env.IsDevelopment() ? exception.StackTrace : null;
                    break;

                case StudentNotAssignedException sna:
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    message = sna.Message;
                    detail = _env.IsDevelopment() ? sna.StackTrace : null;
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    message = "An unexpected error occurred.";
                    detail = _env.IsDevelopment() ? exception.ToString() : null;
                    break;
            }

            context.Response.StatusCode = statusCode;

            _logger.LogError(exception,
                "Unhandled exception. Method: {Method}, Path: {Path}, CorrelationId: {CorrelationId}",
                context.Request.Method,
                context.Request.Path,
                correlationId);

            var response = new ErrorResponseDTO
            {
                CorrelationId = correlationId,
                StatusCode = statusCode,
                Message = message,
                Details = detail
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}