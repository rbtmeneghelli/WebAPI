﻿using System.Linq.Expressions;
using WebAPI.Domain.ValueObject;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class AddressRepository : IAddressRepository
{
    private readonly IGenericReadRepository<AddressData> _iAddressDataReadRepository;
    private readonly IGenericWriteRepository<AddressData> _iAddressDataWriteRepository;

    public AddressRepository(
        IGenericReadRepository<AddressData> iAddressDataReadRepository,
        IGenericWriteRepository<AddressData> iAddressDataWriteRepository)
    {
        _iAddressDataReadRepository = iAddressDataReadRepository;
        _iAddressDataWriteRepository = iAddressDataWriteRepository;
    }

    public IQueryable<AddressData> GetAll(bool hasTracking = false)
    {
        return _iAddressDataReadRepository.GetAll(hasTracking);
    }

    public IQueryable<AddressData> FindBy(Expression<Func<AddressData, bool>> predicate, bool hasTracking = false)
    {
        return _iAddressDataReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public AddressData GetById(long id)
    {
        return _iAddressDataReadRepository.GetById(id);
    }

    public void Update(AddressData ceps)
    {
        _iAddressDataWriteRepository.Update(ceps);
    }

    public void Add(AddressData ceps)
    {
        _iAddressDataWriteRepository.Create(ceps);
    }
}
