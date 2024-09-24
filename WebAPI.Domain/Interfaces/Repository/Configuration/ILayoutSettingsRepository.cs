using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface ILayoutSettingsRepository
{
    IQueryable<LayoutSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<LayoutSettings> FindBy(Expression<Func<LayoutSettings, bool>> predicate, bool hasTracking = false);
    LayoutSettings GetById(long id);
    bool Exist(Expression<Func<LayoutSettings, bool>> predicate);
    void Create(LayoutSettings layoutSettings);
    void Update(LayoutSettings layoutSettings);
}
