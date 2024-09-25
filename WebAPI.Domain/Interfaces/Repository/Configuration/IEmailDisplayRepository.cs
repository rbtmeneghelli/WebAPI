using System.Linq.Expressions;
using WebAPI.Domain.Entities.Configuration;

namespace WebAPI.Domain.Interfaces.Repository.Configuration;

public interface IEmailDisplaySettingsRepository
{
    IQueryable<EmailDisplay> GetAllInclude(string includeData, bool hasTracking = false);
    IQueryable<EmailDisplay> FindBy(Expression<Func<EmailDisplay, bool>> predicate, bool hasTracking = false);
    EmailDisplay GetById(long id);
    bool Exist(Expression<Func<EmailDisplay, bool>> predicate);
    void Create(EmailDisplay emailDisplay);
    void Update(EmailDisplay emailDisplay);
}
