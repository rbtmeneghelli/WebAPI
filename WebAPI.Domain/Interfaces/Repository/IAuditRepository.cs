using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.Interfaces.Repository;

public interface IAuditRepository
{
    IQueryable<Audit> GetAll(bool hasTracking = false);
    Audit GetById(long id);
    IQueryable<Audit> FindBy(Expression<Func<Audit, bool>> predicate, bool hasTracking = false);
    bool Exist(Expression<Func<Audit, bool>> predicate);
}
