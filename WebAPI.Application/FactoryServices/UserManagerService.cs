using WebAPI.Application.FactoryInterfaces;
using IUserService = WebAPI.Application.FactoryInterfaces.IUserService;

namespace WebAPI.Application.FactoryServices
{
    public class UserManagerService : IUserService
    {
        public override Expression<Func<User, bool>> GetPredicate(UserFilter filter)
        {
            return p => p.IdProfile == 1 && 
                        p.IsActive == true;
        }
    }
}
