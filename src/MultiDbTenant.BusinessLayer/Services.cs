using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiDbTenant.BusinessLayer.Abstraction;
using MultiDbTenant.BusinessLayer.Data;
using MultiDbTenant.BusinessLayer.Data.Multitenant;
using MultiDbTenant.BusinessLayer.Repository;
using MultiDbTenant.BusinessLayer.Service;

namespace MultiDbTenant.BusinessLayer;

public static class Services
{
    public static IServiceCollection AddMultiDbTenantBusinessLayer(this IServiceCollection services)
    {
        return services
            .AddDbContext() // Register the DbContext with tenant support
            .AddRepositories() // Register repositories
            .AddServices(); // Register services
    }
    
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        // Register the tenant provider
        services.AddScoped<ITenantProvider, TenantProvider>();

        // Register the tenant connection resolver
        services.AddScoped<IConnectionResolver, AppsettingsConnectionResolver>();

        // Register the DbContext with a factory to resolve the connection string based on the tenant
        services.AddDbContext<TenantDbContext>((serviceProvider, options) =>
        {
            var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
            var connectionResolver = serviceProvider.GetRequiredService<IConnectionResolver>();
            var connectionString = connectionResolver.GetConnectionString(tenantProvider.TenantId);
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IProductRepository, ProductRepository>();
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<IProductService, ProductService>();
    }

}
