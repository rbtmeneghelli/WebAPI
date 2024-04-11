using WebAPI.DesignPatterns.Ioc_Abstract.Entities;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public interface IJobService : IDisposable
{
    Employee GetEmployeeById(int id);

    Boss GetBossById(int id);
}
