using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infra.Repositories.Others;

public class StateRepository : IStatesRepository
{
    private readonly IGenericRepository<States> _repository;

    public StateRepository(IGenericRepository<States> repository)
    {
        _repository = repository;
    }

    public void Add(States state)
    {
        _repository.Add(state);
    }

    public bool Exist(Expression<Func<States, bool>> predicate)
    {
        return _repository.Exist(predicate);
    }

    public IQueryable<States> FindBy(Expression<Func<States, bool>> predicate, bool hasTracking = false)
    {
        return _repository.FindBy(predicate, hasTracking);
    }

    public IQueryable<States> GetAll(bool hasTracking = false)
    {
        return _repository.GetAll(hasTracking);
    }

    public States GetById(long id)
    {
        return _repository.GetById(id);
    }

    public void Remove(States state)
    {
        _repository.Remove(state);
    }

    public void Update(States state)
    {
        _repository.Update(state);
    }

    public void AddRange(IEnumerable<States> states)
    {
        _repository.AddRange(states);
    }
}
