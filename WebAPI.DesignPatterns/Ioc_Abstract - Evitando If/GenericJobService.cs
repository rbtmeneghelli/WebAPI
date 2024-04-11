using WebAPI.Domain;
using WebAPI.DesignPatterns.Ioc_Abstract.Entities;

namespace WebAPI.DesignPatterns.Ioc_Abstract;

public class GenericJobService : IGenericJobService
{
    public readonly Employee _employeeService;
    public readonly Boss _bossService;

    //Fazer IoC das services ou repository é por aqui
    public GenericJobService()
    {
        _employeeService = new Employee();
        _bossService = new Boss();
    }

    public Employee GetEmployeeService() => _employeeService;
    public Boss GetBossService() => _bossService;
}
