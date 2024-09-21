using System.Linq.Expressions;
using WebAPI.Domain.ValueObject;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;

namespace WebAPI.Infra.Repositories.Others;

public class CepRepository : ICepRepository
{
    private readonly IGenericRepository<AddressData> _repository;

    public CepRepository(IGenericRepository<AddressData> repository)
    {
        _repository = repository;
    }

    public IQueryable<AddressData> GetAll(bool hasTracking = false)
    {
        return _repository.GetAll(hasTracking);
    }

    public void Update(AddressData ceps)
    {
        _repository.Update(ceps);
    }

    public void Add(AddressData ceps)
    {
        _repository.Add(ceps);
    }

    public IQueryable<AddressData> FindBy(Expression<Func<AddressData, bool>> predicate, bool hasTracking = false)
    {
        return _repository.FindBy(predicate, hasTracking);
    }

    public AddressData GetById(long id)
    {
        return _repository.GetById(id);
    }
}
