using WebAPI.Domain;

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
        return GuardClauses.IsNullOrWhiteSpace(name) ? FixConstants.GetEmptyString() : name;
    }

    protected virtual int GenerateId()
    {
        return Random.Shared.Next(1, int.MaxValue);
    }
}
