using WebAPI.DesignPatterns.Ioc_Abstract.Entities;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public interface IGenericJobService
{
    Employee GetEmployeeService();
    Boss GetBossService();
}
