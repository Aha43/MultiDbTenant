using Microsoft.Extensions.DependencyInjection;
using MultiDbTenant.BusinessLayer.Data;

namespace MultiDbTenant.BusinessLayer;

public static class Services
{
    public static IServiceCollection AddMultiDbTenantServices(this IServiceCollection services)
    {
        // Register the tenant provider
        services.AddScoped<ITenantProvider, TenantProvider>();

        // Register the tenant connection resolver
        services.AddScoped<TenantConnectionResolver>();

        // Register the DbContext with a factory to resolve the connection string based on the tenant
        services.AddDbContext<TenantDbContext>((serviceProvider, options) =>
        {
            var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
            var connectionResolver = serviceProvider.GetRequiredService<TenantConnectionResolver>();
            var connectionString = connectionResolver.GetConnectionString(tenantProvider.TenantId);
            options.UseSqlServer(connectionString);
        });

        return services;
    }

}
