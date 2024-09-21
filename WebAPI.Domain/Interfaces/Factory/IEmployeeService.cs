using System.Linq.Expressions;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Filters.ControlPanel;

namespace WebAPI.Domain.Interfaces.Factory;

public abstract class IEmployeeService
{
    public abstract Expression<Func<Employee, bool>> GetPredicate(EmployeeFilter filter);
}
