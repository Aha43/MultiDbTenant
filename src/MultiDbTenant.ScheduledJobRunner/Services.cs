using System;
using Microsoft.Extensions.DependencyInjection;

namespace MultiDbTenant.ScheduledJobRunner;

public static class Services
{
    public static IServiceCollection AddScheduledJobRunnerServices(this IServiceCollection services)
    {
        // Register the job dispatcher
        services.AddSingleton<JobDispatcher>();

        // Register the job runner
        services.AddHostedService<JobRunner>();

        // Register the job types
        services.Scan(scan => scan
            .FromAssemblyOf<IJob>()
            .AddClasses(classes => classes.AssignableTo<IJob>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
