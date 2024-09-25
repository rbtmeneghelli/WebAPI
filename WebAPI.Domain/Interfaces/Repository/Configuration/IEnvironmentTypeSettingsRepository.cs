using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IEnvironmentTypeSettingsRepository
{
    IQueryable<EnvironmentTypeSettings> GetAll(bool hasTracking = false);
    IQueryable<EnvironmentTypeSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<EnvironmentTypeSettings> FindBy(Expression<Func<EnvironmentTypeSettings, bool>> predicate, bool hasTracking = false);
    EnvironmentTypeSettings GetById(long id);
    bool Exist(Expression<Func<EnvironmentTypeSettings, bool>> predicate);
    void Create(EnvironmentTypeSettings environmentTypeSettings);
    void Update(EnvironmentTypeSettings environmentTypeSettings);
}
