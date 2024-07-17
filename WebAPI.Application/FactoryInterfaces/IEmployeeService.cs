using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Application.FactoryInterfaces
{
    public abstract class IEmployeeService
    {
        public abstract Expression<Func<Employee, bool>> GetPredicate(EmployeeFilter filter);
    }
}
