using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using IEmployeeService = WebAPI.Application.FactoryInterfaces.IEmployeeService;

namespace WebAPI.Application.FactoryServices;

public class EmployeeDefaultService : IEmployeeService
{
    public override Expression<Func<Employee, bool>> GetPredicate(EmployeeFilter filter)
    {
        return p => filter.IdProfile == 2 &&
                    p.Status == true;
    }
}
