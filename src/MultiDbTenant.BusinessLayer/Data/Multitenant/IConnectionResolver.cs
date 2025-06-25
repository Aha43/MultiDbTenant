namespace MultiDbTenant.BusinessLayer.Data.Multitenant;

public interface IConnectionResolver
{
    string GetConnectionString(string tenantId);
}
