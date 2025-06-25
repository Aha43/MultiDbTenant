namespace MultiDbTenant.ScheduledJobRunner.Abstraction;

public interface IJob
{
    string Name { get; }
    Task ExecuteAsync();
}
