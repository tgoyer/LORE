using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace LORE.WebApi.Services.Middleware
{
    public static class ConsoleLogMiddlewareExtensions
    {
        public static void UseConsoleLog(this IAppBuilder app)
        {
            app.Use<ConsoleLogMiddleware>();
        }
    }

    public class ConsoleLogMiddleware : OwinMiddleware
    {
        public ConsoleLogMiddleware(OwinMiddleware next)
            : base(next)
        {

        }

        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Request received ({0} {1})...", context.Request.Method, context.Request.Uri);
            var now = DateTime.Now;
            await Next.Invoke(context);
            var timespan = (DateTime.Now - now).Milliseconds;
            Console.WriteLine("\tRequest processed in {0} ms with Status Code: {1}.\n", timespan, context.Response.StatusCode);
        }
    }
}
