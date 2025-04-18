using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Models.Factory;

namespace WebAPI.Application.Factory;

public sealed class UserFactory : IEmployeeFactory
{
    public static IEmployeeService GetData(int enumProfileType)
    {

        IEmployeeService userData;

        switch (enumProfileType)
        {
            case 1:
                userData = new EmployeeDefaultService();
                break;
            case 2:
                userData = new EmployeeDefaultService();
                break;
            case 3:
                userData = new EmployeeDefaultService();
                break;
            default:
                throw new ApplicationException();
        }

        return userData;
    }

    public override IEmployeeService GetDataMinimal(int enumProfileType)
    {
        try
        {
            return EmployeeDefaultFactory[enumProfileType]();
        }
        catch(Exception ex)
        {
            return EmployeeDefaultFactory[1]();
        }
    }
}
