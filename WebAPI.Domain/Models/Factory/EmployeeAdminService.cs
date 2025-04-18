using System.Linq.Expressions;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;
using WebAPI.Domain.Interfaces.Factory;

namespace WebAPI.Domain.Models.Factory;

public class EmployeeAdminService : IEmployeeService
{
    public override Expression<Func<Employee, bool>> GetPredicate(EmployeeFilter filter)
    {
        return p => filter.IdProfile == 3 &&
                    p.IsActive == true;
    }
}
