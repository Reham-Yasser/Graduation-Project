using Edu_Chatbot.Errors;
using System.Net;
using System.Text.Json;

namespace Edu_Chatbot.MiddelWare
{
    public class ExceptionMiddlWare
    {

            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionMiddlWare> _logger;
            private readonly IHostEnvironment _env;

            public ExceptionMiddlWare(RequestDelegate next, ILogger<ExceptionMiddlWare> logger, IHostEnvironment env)
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
                    _logger.LogError(ex, ex.Message);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var response = _env.IsDevelopment()
                          ? new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                        : new ApiResponse((int)HttpStatusCode.InternalServerError, ex.StackTrace.ToString());
                    var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                    var json = JsonSerializer.Serialize(response, options);

                    await context.Response.WriteAsync(json);
                }
            }
        }
}



        

