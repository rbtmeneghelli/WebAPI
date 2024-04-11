using WebAPI.Application.FactoryServices;

namespace WebAPI.Application.FactoryInterfaces
{
    public abstract class IUserFactory
    {
        public abstract IUserService GetDataMinimal(int enumProfileType);

        protected static Dictionary<int, Func<IUserService>> UserDefaultFactory = new Dictionary<int, Func<IUserService>>
        {
                  { 1, ()=>new UserDefaultService() },
                  { 2, ()=>new UserAdminService() },
                  { 3, ()=>new UserManagerService()},
        };
    }
}
