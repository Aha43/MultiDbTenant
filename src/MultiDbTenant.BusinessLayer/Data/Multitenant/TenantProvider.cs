namespace MultiDbTenant.BusinessLayer.Data.Multitenant;

public class TenantProvider : ITenantProvider
{
    public string TenantId { get; set; } = string.Empty;
}
