using GreenDiamond.Domain.Interface.GreenDiaiondConnection;
using Microsoft.IdentityModel.Tokens;

namespace GreenDiamond.WebApi.Middelvare
{
    public class MultiGreenDimaondMiddleware
    {
        private readonly RequestDelegate _next;

        public MultiGreenDimaondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Get Tenant Id from incoming requests
        public async Task InvokeAsync(HttpContext context, IConnection connection)
        {
            // Extract tenant identifier from the request headers
            if (!context.Request.Headers.TryGetValue("", out var tenantFromHeader) || string.IsNullOrEmpty(tenantFromHeader))
            {
                // Handle missing tenant identifier
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("");
                return;
            }

            // Check if the tenant ID should be skipped
            if (tenantFromHeader == "")
            {
                await _next(context);
                return;
            }

            // Set up database connection for the tenant
            await connection.SetGreenDimoand(tenantFromHeader);

            await _next(context);
        }
    }
}
