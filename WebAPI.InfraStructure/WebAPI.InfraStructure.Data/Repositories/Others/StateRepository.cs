using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class StateRepository : IStatesRepository
{
    private readonly IReadRepository<States> _iStateReadRepository;
    private readonly IWriteRepository<States> _iStateWriteRepository;

    public StateRepository(
        IReadRepository<States> iStateReadRepository,
        IWriteRepository<States> iStateWriteRepository)
    {
        _iStateReadRepository = iStateReadRepository;
        _iStateWriteRepository = iStateWriteRepository;
    }

    public bool Exist(Expression<Func<States, bool>> predicate)
    {
        return _iStateReadRepository.Exist(predicate);
    }

    public IQueryable<States> FindBy(Expression<Func<States, bool>> predicate, bool hasTracking = false)
    {
        return _iStateReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public IQueryable<States> GetAll(bool hasTracking = false)
    {
        return _iStateReadRepository.GetAll(hasTracking);
    }

    public States GetById(long id)
    {
        return _iStateReadRepository.GetById(id);
    }

    public void Add(States state)
    {
        _iStateWriteRepository.Create(state);
    }

    public void AddRange(IEnumerable<States> states)
    {
        _iStateWriteRepository.BulkCreate(states);
    }

    public void Update(States state)
    {
        _iStateWriteRepository.Update(state);
    }

    public void Remove(States state)
    {
        _iStateWriteRepository.Remove(state);
    }
}
