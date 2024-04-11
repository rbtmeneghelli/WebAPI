using WebAPI.Application;
using WebAPI.Application.Interfaces;
using WebAPI.Domain.Entities;
using System.Linq.Expressions;

namespace WebAPI.Infra.Data.Repositories;

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
