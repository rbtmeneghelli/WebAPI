using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infra.Repositories.Others;

public class AuditRepository : IAuditRepository
{
    private readonly IGenericRepository<Audit> _iAuditRepository;

    public AuditRepository(IGenericRepository<Audit> iAuditRepository)
    {
        _iAuditRepository = iAuditRepository;
    }

    public IQueryable<Audit> GetAll(bool hasTracking = false)
    {
        return _iAuditRepository.GetAll(hasTracking);
    }

    public Audit GetById(long id)
    {
        return _iAuditRepository.GetById(id);
    }

    public IQueryable<Audit> FindBy(Expression<Func<Audit, bool>> predicate, bool hasTracking = false)
    {
        return _iAuditRepository.FindBy(predicate, hasTracking);
    }

    public bool Exist(Expression<Func<Audit, bool>> predicate)
    {
        return _iAuditRepository.Exist(predicate);
    }
}
