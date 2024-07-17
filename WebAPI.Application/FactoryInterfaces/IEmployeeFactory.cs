using WebAPI.Application.FactoryServices;

namespace WebAPI.Application.FactoryInterfaces;

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
