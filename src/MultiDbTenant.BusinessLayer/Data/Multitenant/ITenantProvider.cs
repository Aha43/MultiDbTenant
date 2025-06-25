namespace MultiDbTenant.BusinessLayer.Data.Multitenant;

public interface ITenantProvider
{
    string TenantId { get; set; }
}
