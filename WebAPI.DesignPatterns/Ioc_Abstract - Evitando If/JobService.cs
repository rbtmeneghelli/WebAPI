using WebAPI.DesignPatterns.Ioc_Abstract.Entities;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public class JobService : IJobService
{
    public JobService() { }

    public Employee GetEmployeeById(int id)
    {
        return new Employee();
    }

    public Boss GetBossById(int id)
    {
        return new Boss();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
