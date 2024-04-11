using WebAPI.Application.FactoryInterfaces;
using IUserService = WebAPI.Application.FactoryInterfaces.IUserService;

namespace WebAPI.Application.FactoryServices
{
    public class UserDefaultService : IUserService
    {
        public override Expression<Func<User, bool>> GetPredicate(UserFilter filter)
        {
            return p => filter.IdProfile == 2 &&
                        p.IsActive == true;
        }
    }
}
