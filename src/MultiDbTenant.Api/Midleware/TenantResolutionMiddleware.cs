using MultiDbTenant.BusinessLayer.Data;

namespace MultiDbTenant.Api.Midleware;

public class TenantResolutionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider)
    {
        if (context.Request.Headers.TryGetValue("X-Tenant-ID", out var tenantId))
        {
            tenantProvider.TenantId = tenantId!;
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Tenant ID is missing");
            return;
        }

        await _next(context);
    }
}
