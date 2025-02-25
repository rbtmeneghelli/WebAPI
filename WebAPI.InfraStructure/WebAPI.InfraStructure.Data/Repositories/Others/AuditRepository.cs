using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class AuditRepository : IAuditRepository
{
    private readonly IReadRepository<Audit> _iAuditReadRepository;

    public AuditRepository(IReadRepository<Audit> iAuditReadRepository)
    {
        _iAuditReadRepository = iAuditReadRepository;
    }

    public IQueryable<Audit> GetAll(bool hasTracking = false)
    {
        return _iAuditReadRepository.GetAll(hasTracking);
    }

    public Audit GetById(long id)
    {
        return _iAuditReadRepository.GetById(id);
    }

    public IQueryable<Audit> FindBy(Expression<Func<Audit, bool>> predicate, bool hasTracking = false)
    {
        return _iAuditReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public bool Exist(Expression<Func<Audit, bool>> predicate)
    {
        return _iAuditReadRepository.Exist(predicate);
    }
}
