namespace WebAPI.Application.InterfacesRepository;

public interface ILogRepository
{
    IQueryable<Log> GetAll(bool hasTracking = false);
    Log GetById(long id);
    IQueryable<Log> FindBy(Expression<Func<Log, bool>> predicate, bool hasTracking = false);
    bool Exist(Expression<Func<Log, bool>> predicate);
}
