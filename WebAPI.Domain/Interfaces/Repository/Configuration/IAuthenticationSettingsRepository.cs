using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IAuthenticationSettingsRepository
{
    IQueryable<AuthenticationSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<AuthenticationSettings> FindBy(Expression<Func<AuthenticationSettings, bool>> predicate, bool hasTracking = false);
    AuthenticationSettings GetById(long id);
    bool Exist(Expression<Func<AuthenticationSettings, bool>> predicate);
    void Create(AuthenticationSettings authenticationSettings);
    void Update(AuthenticationSettings authenticationSettings);
}
