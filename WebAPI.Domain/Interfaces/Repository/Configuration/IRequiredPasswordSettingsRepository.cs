using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IRequiredPasswordSettingsRepository
{
    IQueryable<RequiredPasswordSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<RequiredPasswordSettings> FindBy(Expression<Func<RequiredPasswordSettings, bool>> predicate, bool hasTracking = false);
    RequiredPasswordSettings GetById(long id);
    bool Exist(Expression<Func<RequiredPasswordSettings, bool>> predicate);
    void Create(RequiredPasswordSettings requiredPasswordSettings);
    void Update(RequiredPasswordSettings requiredPasswordSettings);
}
