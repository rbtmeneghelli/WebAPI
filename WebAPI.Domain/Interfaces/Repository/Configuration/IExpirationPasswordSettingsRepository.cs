using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IExpirationPasswordSettingsRepository
{
    IQueryable<ExpirationPasswordSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<ExpirationPasswordSettings> FindBy(Expression<Func<ExpirationPasswordSettings, bool>> predicate, bool hasTracking = false);
    ExpirationPasswordSettings GetById(long id);
    bool Exist(Expression<Func<ExpirationPasswordSettings, bool>> predicate);
    void Create(ExpirationPasswordSettings expirationPasswordSettings);
    void Update(ExpirationPasswordSettings expirationPasswordSettings);
}
