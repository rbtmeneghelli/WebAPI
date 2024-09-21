using WebAPI.Domain.Models.Factory;

namespace WebAPI.Domain.Interfaces.Factory;

public abstract class IEmployeeFactory
{
    public abstract IEmployeeService GetDataMinimal(int enumProfileType);

    protected static Dictionary<int, Func<IEmployeeService>> EmployeeDefaultFactory = new Dictionary<int, Func<IEmployeeService>>
    {
              { 1, ()=>new EmployeeDefaultService() },
              { 2, ()=>new EmployeeAdminService() },
              { 3, ()=>new EmployeeManagerService()},
    };
}
