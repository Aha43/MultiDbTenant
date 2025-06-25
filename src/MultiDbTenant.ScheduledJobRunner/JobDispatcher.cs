using Microsoft.Extensions.DependencyInjection;
using MultiDbTenant.BusinessLayer.Data.Multitenant;
using MultiDbTenant.ScheduledJobRunner.Abstraction;

namespace MultiDbTenant.ScheduledJobRunner;

public class JobDispatcher(
    IServiceProvider rootServiceProvider,
    IEnumerable<IJob> jobs)
{
    public void DispatchJob(string tenantId, string jobName)
    {
        var scope = rootServiceProvider.CreateScope();
        var provider = scope.ServiceProvider;
        var tenantProvider = provider.GetRequiredService<ITenantProvider>();
        tenantProvider.TenantId = tenantId;
    }
}
