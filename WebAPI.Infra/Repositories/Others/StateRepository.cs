using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infra.Repositories.Others;

public class StateRepository : IStatesRepository
{
    private readonly IGenericRepository<States> _iStateRepository;

    public StateRepository(IGenericRepository<States> iStateRepository)
    {
        _iStateRepository = iStateRepository;
    }

    public void Add(States state)
    {
        _iStateRepository.Add(state);
    }

    public bool Exist(Expression<Func<States, bool>> predicate)
    {
        return _iStateRepository.Exist(predicate);
    }

    public IQueryable<States> FindBy(Expression<Func<States, bool>> predicate, bool hasTracking = false)
    {
        return _iStateRepository.FindBy(predicate, hasTracking);
    }

    public IQueryable<States> GetAll(bool hasTracking = false)
    {
        return _iStateRepository.GetAll(hasTracking);
    }

    public States GetById(long id)
    {
        return _iStateRepository.GetById(id);
    }

    public void Remove(States state)
    {
        _iStateRepository.Remove(state);
    }

    public void Update(States state)
    {
        _iStateRepository.Update(state);
    }

    public void AddRange(IEnumerable<States> states)
    {
        _iStateRepository.AddRange(states);
    }
}
