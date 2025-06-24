using Microsoft.Extensions.Configuration;

namespace MultiDbTenant.BusinessLayer.Data;

public class TenantConnectionResolver(IConfiguration config)
{
    public string GetConnectionString(string tenantId)
    {
        return config.GetConnectionString(tenantId) 
            ?? throw new Exception($"Connection string for tenant '{tenantId}' not found.");
    }
}
