namespace WebAPI.Application.FactoryInterfaces
{
    public abstract class IUserService
    {
        public abstract Expression<Func<User, bool>> GetPredicate(UserFilter filter);
    }
}
