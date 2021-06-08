using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WarAndPeace.API.Middleware
{

    public class ResponseTimeMiddleware
    {
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time";
        private readonly RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() =>
            {
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedTicks;
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                return Task.CompletedTask;
            });
            
            return _next(context);
        }
    }

    public static class ResponseTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseTimeMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseTimeMiddleware>();
        }
    }
}