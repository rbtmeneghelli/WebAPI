using WebAPI.Domain.Entities.ControlPanel;
using IEmployeeService = WebAPI.Application.FactoryInterfaces.IEmployeeService;

namespace WebAPI.Application.FactoryServices;

public class EmployeeAdminService : IEmployeeService
{
    public override Expression<Func<Employee, bool>> GetPredicate(EmployeeFilter filter)
    {
        return p => filter.IdProfile == 3 &&
                    p.IsActive == true;
    }
}
