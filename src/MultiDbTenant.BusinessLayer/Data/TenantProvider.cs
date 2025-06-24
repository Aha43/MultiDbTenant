namespace MultiDbTenant.BusinessLayer.Data;

public class TenantProvider : ITenantProvider
{
    public string TenantId { get; set; } = string.Empty;
}
