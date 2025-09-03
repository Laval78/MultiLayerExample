using MultiLayerExample.Domain.Exceptions;
using System.Net;
using System.Text.Json;
using Serilog;

namespace MultiLayerExample.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                Log.Error(ex, "Exception caught");

                await HandleAsync(context, ex);
            }
        }

        public async Task HandleAsync(HttpContext context, Exception exception) 
        { 
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch 
            { 
                BadRequestException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new 
            { 
                error = exception.Message,
                statusCode = context.Response.StatusCode
            });

            await context.Response.WriteAsync(result);
        }
    }
}
