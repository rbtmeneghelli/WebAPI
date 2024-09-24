using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IEmailSettingsRepository
{
    IQueryable<EmailSettings> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<EmailSettings> FindBy(Expression<Func<EmailSettings, bool>> predicate, bool hasTracking = false);
    EmailSettings GetById(long id);
    bool Exist(Expression<Func<EmailSettings, bool>> predicate);
    void Create(EmailSettings emailSettings);
    void Update(EmailSettings emailSettings);
}
