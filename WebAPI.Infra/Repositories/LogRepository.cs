using WebAPI.Domain.Entities;
using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;

namespace WebAPI.Infra.Data.Repositories;

public class LogRepository : ILogRepository
{
    private readonly IGenericRepository<Log> _repository;

    public LogRepository(IGenericRepository<Log> repository)
    {
        _repository = repository;
    }

    public bool Exist(Expression<Func<Log, bool>> predicate)
    {
        return _repository.Exist(predicate);
    }

    public IQueryable<Log> FindBy(Expression<Func<Log, bool>> predicate, bool hasTracking = false)
    {
        return _repository.FindBy(predicate, hasTracking);
    }

    public IQueryable<Log> GetAll(bool hasTracking = false)
    {
        return _repository.GetAll(hasTracking);
    }

    public Log GetById(long id)
    {
        return _repository.GetById(id);
    }
}
