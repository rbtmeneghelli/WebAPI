using WebAPI.Application.FactoryInterfaces;
using WebAPI.Application.FactoryServices;
using WebAPI.Domain.Models.Generic;
using IEmployeeService = WebAPI.Application.FactoryInterfaces.IEmployeeService;

namespace WebAPI.Application.Factory
{
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
            catch(GenericException ex)
            {
                ex.ShowDefaultExceptionMessage();
                return EmployeeDefaultFactory[1]();
            }
        }
    }
}
