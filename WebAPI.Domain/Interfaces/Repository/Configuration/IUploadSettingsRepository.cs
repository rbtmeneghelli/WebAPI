using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IUploadSettingsRepository
{
    IQueryable<UploadSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<UploadSettings> FindBy(Expression<Func<UploadSettings, bool>> predicate, bool hasTracking = false);
    UploadSettings GetById(long id);
    bool Exist(Expression<Func<UploadSettings, bool>> predicate);
    void Create(UploadSettings uploadSettings);
    void Update(UploadSettings uploadSettings);
}
