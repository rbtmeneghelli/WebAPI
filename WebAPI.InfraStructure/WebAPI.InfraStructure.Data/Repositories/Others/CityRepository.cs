using WebAPI.InfraStructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Generic;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class CityRepository : ICityRepository
{
    private readonly WebAPIContext _context;
    private readonly IReadRepository<City> _iCityReadRepository;
    private readonly IWriteRepository<City> _iCityWriteRepository;

    public CityRepository(
        IReadRepository<City> iCityReadRepository,
        IWriteRepository<City> iCityWriteRepository,
        WebAPIContext context)
    {
        _iCityReadRepository = iCityReadRepository;
        _iCityWriteRepository = iCityWriteRepository;
        _context = context;
    }

    public IQueryable<City> GetAll(bool hasTracking = false)
    {
        return _iCityReadRepository.GetAll(hasTracking);
    }

    public IQueryable<City> FindBy(Expression<Func<City, bool>> predicate, bool hasTracking = false)
    {
        return _iCityReadRepository.GetByPredicate(predicate, hasTracking);
    }
    public City GetById(long id)
    {
        return _iCityReadRepository.GetById(id);
    }

    public bool Exist(Expression<Func<City, bool>> predicate)
    {
        return _iCityReadRepository.Exist(predicate);
    }

    public void Add(City city)
    {
        _iCityWriteRepository.Create(city);
    }

    public void Update(City city)
    {
        _iCityWriteRepository.Update(city);
    }

    public void Remove(City city)
    {
        _iCityWriteRepository.Remove(city);
    }

    /// <summary>
    /// Performance em Bulk Update sem sobrecarregar a memoria
    /// </summary>
    /// <param name="city"></param>
    public void ExecuteUpdate(City city)
    {
        string stIBGE = city.IBGE.HasValue ? city.IBGE.Value.ToString() : "00000000";

        _context.City
                .Where(x => x.IBGE == city.IBGE && x.StateId == city.StateId)
                .ExecuteUpdate(setter => setter
                .SetProperty(p => p.Name, city.Name)
                .SetProperty(p => p.IBGE, long.Parse(stIBGE))
                .SetProperty(p => p.StateId, city.StateId)
                .SetProperty(p => p.Status, true)
                .SetProperty(p => p.UpdateDate, DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()));
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
