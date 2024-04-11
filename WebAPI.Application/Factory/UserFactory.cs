using WebAPI.Application.FactoryInterfaces;
using WebAPI.Application.FactoryServices;
using WebAPI.Domain.Generic;
using IUserService = WebAPI.Application.FactoryInterfaces.IUserService;

namespace WebAPI.Application.Factory
{
    public sealed class UserFactory : IUserFactory
    {
        public static IUserService GetData(int enumProfileType)
        {

            IUserService userData;

            switch (enumProfileType)
            {
                case 1:
                    userData = new UserDefaultService();
                    break;
                case 2:
                    userData = new UserDefaultService();
                    break;
                case 3:
                    userData = new UserDefaultService();
                    break;
                default:
                    throw new ApplicationException();
            }

            return userData;
        }

        public override IUserService GetDataMinimal(int enumProfileType)
        {
            try
            {
                return UserDefaultFactory[enumProfileType]();
            }
            catch(GenericException ex)
            {
                ex.ShowDefaultExceptionMessage();
                return UserDefaultFactory[1]();
            }
        }
    }
}
