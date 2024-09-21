using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Infra.Repositories.Others;

public class AuditRepository : IAuditRepository
{
    private readonly IGenericRepository<Audit> _repository;

    public AuditRepository(IGenericRepository<Audit> repository)
    {
        _repository = repository;
    }

    public IQueryable<Audit> GetAll(bool hasTracking = false)
    {
        return _repository.GetAll(hasTracking);
    }

    public Audit GetById(long id)
    {
        return _repository.GetById(id);
    }

    public IQueryable<Audit> FindBy(Expression<Func<Audit, bool>> predicate, bool hasTracking = false)
    {
        return _repository.FindBy(predicate, hasTracking);
    }

    public bool Exist(Expression<Func<Audit, bool>> predicate)
    {
        return _repository.Exist(predicate);
    }
}
