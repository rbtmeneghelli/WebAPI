using System.Linq.Expressions;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Domain.Interfaces.Repository;

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
    Task<IEnumerable<User>> UserProfileJoinLinq();
    Task<IEnumerable<User>> UserProfileJoinLinqAndLambda();
    Task<IEnumerable<User>> UserProfileLeftJoinLinq();
    Task<IEnumerable<User>> UserProfileRightJoinLinq();
    Task<IEnumerable<User>> UserProfileFullJoinLinq();
    bool Exist(Expression<Func<User, bool>> predicate);
    void Add(User user);
    void Remove(User user);
}

