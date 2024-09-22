using System.Linq.Expressions;
using WebAPI.Domain.ValueObject;
using WebAPI.Application.Generic;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infra.Repositories.Others;

public class AddressRepository : IAddressRepository
{
    private readonly IGenericRepository<AddressData> _iAddressDataRepository;

    public AddressRepository(IGenericRepository<AddressData> iAddressDataRepository)
    {
        _iAddressDataRepository = iAddressDataRepository;
    }

    public IQueryable<AddressData> GetAll(bool hasTracking = false)
    {
        return _iAddressDataRepository.GetAll(hasTracking);
    }

    public void Update(AddressData ceps)
    {
        _iAddressDataRepository.Update(ceps);
    }

    public void Add(AddressData ceps)
    {
        _iAddressDataRepository.Add(ceps);
    }

    public IQueryable<AddressData> FindBy(Expression<Func<AddressData, bool>> predicate, bool hasTracking = false)
    {
        return _iAddressDataRepository.FindBy(predicate, hasTracking);
    }

    public AddressData GetById(long id)
    {
        return _iAddressDataRepository.GetById(id);
    }
}
