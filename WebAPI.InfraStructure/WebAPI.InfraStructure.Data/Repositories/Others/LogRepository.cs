using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class LogRepository : ILogRepository
{
    private readonly IGenericRepository<Log> _iLogRepository;

    public LogRepository(IGenericRepository<Log> iLogRepository)
    {
        _iLogRepository = iLogRepository;
    }

    public bool Exist(Expression<Func<Log, bool>> predicate)
    {
        return _iLogRepository.Exist(predicate);
    }

    public IQueryable<Log> FindBy(Expression<Func<Log, bool>> predicate, bool hasTracking = false)
    {
        return _iLogRepository.FindBy(predicate, hasTracking);
    }

    public IQueryable<Log> GetAll(bool hasTracking = false)
    {
        return _iLogRepository.GetAll(hasTracking);
    }

    public Log GetById(long id)
    {
        return _iLogRepository.GetById(id);
    }
}
