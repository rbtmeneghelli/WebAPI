namespace WebAPI.Application.Interfaces;

public interface IStatesRepository
{
    IQueryable<States> GetAll(bool hasTracking = false);
    States GetById(long id);
    IQueryable<States> FindBy(Expression<Func<States, bool>> predicate, bool hasTracking = false);
    bool Exist(Expression<Func<States, bool>> predicate);
    void Add(States state);
    void Remove(States state);
    void Update(States state);
    void AddRange(IEnumerable<States> states);
}
