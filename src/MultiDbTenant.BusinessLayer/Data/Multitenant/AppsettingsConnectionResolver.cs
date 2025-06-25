using Microsoft.Extensions.Configuration;

namespace MultiDbTenant.BusinessLayer.Data.Multitenant;

public class AppsettingsConnectionResolver(IConfiguration config) : IConnectionResolver
{
    public string GetConnectionString(string tenantId)
    {
        return config.GetConnectionString(tenantId) 
            ?? throw new Exception($"Connection string for tenant '{tenantId}' not found.");
    }
}
