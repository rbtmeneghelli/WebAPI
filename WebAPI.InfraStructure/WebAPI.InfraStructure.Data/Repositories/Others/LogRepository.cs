using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class LogRepository : ILogRepository
{
    private readonly IReadRepository<Log> _iLogReadRepository;

    public LogRepository(IReadRepository<Log> iLogReadRepository)
    {
        _iLogReadRepository = iLogReadRepository;
    }

    public bool Exist(Expression<Func<Log, bool>> predicate)
    {
        return _iLogReadRepository.Exist(predicate);
    }

    public IQueryable<Log> FindBy(Expression<Func<Log, bool>> predicate, bool hasTracking = false)
    {
        return _iLogReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public IQueryable<Log> GetAll(bool hasTracking = false)
    {
        return _iLogReadRepository.GetAll(hasTracking);
    }

    public Log GetById(long id)
    {
        return _iLogReadRepository.GetById(id);
    }
}
