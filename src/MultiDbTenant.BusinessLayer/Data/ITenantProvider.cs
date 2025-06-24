namespace MultiDbTenant.BusinessLayer.Data;

public interface ITenantProvider
{
    string TenantId { get; set; }
}
