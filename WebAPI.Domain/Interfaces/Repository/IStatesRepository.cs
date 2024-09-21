using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.Interfaces.Repository;

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
