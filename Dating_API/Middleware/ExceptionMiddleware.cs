using System.Net;
using System.Text.Json;
using Dating_API.Error;

namespace Dating_API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ILogger<ExceptionMiddleware> _Logger;
        public IHostEnvironment _Env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            _Env = env;
            _Logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try{
                await _next(context);
            }
            catch(Exception ex){
                _Logger.LogError(ex,ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

                var response=_Env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                    :new ApiException(context.Response.StatusCode,ex.Message,"Internal Server Error");
                
                var options=new JsonSerializerOptions{PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
                var json=JsonSerializer.Serialize(response,options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}