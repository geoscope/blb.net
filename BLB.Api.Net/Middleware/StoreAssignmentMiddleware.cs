using System.Globalization;
using System.Threading.Tasks;
using BLB.Api.Net.interfaces;
using BLB.Shared.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BLB.Api.Net.Middleware
{
    public class StoreAssignmentMiddleware
    {
        private readonly RequestDelegate _next;

        // This middleware assigns the store id to the browsing user, wether authenticated or not
        public StoreAssignmentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IOptions<AppSettings> appSettings, IStoreHostNameService hostNameService)
        {

            //TODO: Refactor to external class for easier unit testing:
            if (context.Request.Headers["x-store-id"].Count == 1 && !string.IsNullOrWhiteSpace(context.Request.Headers["x-store-id"].ToString()))
            {
                if (long.TryParse(context.Request.Headers["x-store-id"].ToString(), out long storeId))
                {
                    context.Items["storeId"] = storeId;
                }
            }
            else
            {
                // get store id from the host name
                var storeHostName = await hostNameService.GetStoreHostNameAsync(context.Request.Host.Host);
                if (storeHostName != null)
                {
                    context.Items["storeId"] = storeHostName.StoreId;
                }
                else
                {
                    // if all else fails, use the default store id
                    context.Items["storeId"] = appSettings.Value.DefaultStoreId;
                }
            }

            await _next(context);
        }
    }
}
