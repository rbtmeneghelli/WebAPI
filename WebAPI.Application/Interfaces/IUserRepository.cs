namespace WebAPI.Application.Interfaces;

public interface IUserRepository
{
    IQueryable<User> GetAll(bool hasTracking = false);
    IQueryable<User> GetAllIgnoreQueryFilter(bool hasTracking = false);
    IQueryable<User> FindBy(Expression<Func<User, bool>> predicate);
    IQueryable<User> FindByIgnoreQueryFilter(Expression<Func<User, bool>> predicate);
    User GetById(long id);
    void Update(User user);
    Task<User> GetUserCredentialsByLogin(string login);
    Task<User> GetUserCredentialsById(long id);
    Task<bool> CanDelete(long userId);
    Task<List<User>> UserProfileJoinLinq();
    Task<List<User>> UserProfileJoinLinqAndLambda();
    Task<List<User>> UserProfileLeftJoinLinq();
    Task<List<User>> UserProfileRightJoinLinq();
    Task<List<User>> UserProfileFullJoinLinq();
    bool Exist(Expression<Func<User, bool>> predicate);
    void Add(User user);
    void Remove(User user);
}

