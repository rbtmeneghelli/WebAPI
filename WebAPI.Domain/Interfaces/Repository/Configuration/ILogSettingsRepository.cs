using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface ILogSettingsRepository
{
    IQueryable<LogSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<LogSettings> FindBy(Expression<Func<LogSettings, bool>> predicate, bool hasTracking = false);
    LogSettings GetById(long id);
    bool Exist(Expression<Func<LogSettings, bool>> predicate);
    void Create(LogSettings requiredPasswordSettings);
    void Update(LogSettings requiredPasswordSettings);
}
