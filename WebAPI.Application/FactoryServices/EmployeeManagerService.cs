using WebAPI.Application.FactoryInterfaces;
using WebAPI.Domain.Entities.ControlPanel;
using IEmployeeService = WebAPI.Application.FactoryInterfaces.IEmployeeService;

namespace WebAPI.Application.FactoryServices;

public class EmployeeManagerService : IEmployeeService
{
    public override Expression<Func<Employee, bool>> GetPredicate(EmployeeFilter filter)
    {
        return p => p.IdProfile == 1 && 
                    p.IsActive == true;
    }
}
