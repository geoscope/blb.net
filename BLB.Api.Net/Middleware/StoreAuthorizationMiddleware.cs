using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BLB.Api.Net.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class StoreAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public StoreAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers["x-store-id"].Count == 1 && !string.IsNullOrWhiteSpace(context.Request.Headers["x-store-id"][0].ToString()))
            {
                if (long.TryParse(context.Request.Headers["x-store-id"].ToString(), out long storeId))
                {

                }
            }

            await _next(context);
        }
    }
}
