using FastPackForShare.Extensions;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public abstract class BaseJobService<T> where T : class
{
    protected readonly IJobService _jobService;

    public BaseJobService(IJobService jobService)
    {
        _jobService = jobService;
    }

    public abstract decimal CalculateSalary(T entity);

    protected virtual string RemoveSpaces(string name)
    {
        return GuardClauseExtension.IsNullOrWhiteSpace(name) ? string.Empty : name;
    }

    protected virtual int GenerateId()
    {
        return Random.Shared.Next(1, int.MaxValue);
    }
}
