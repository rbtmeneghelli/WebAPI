using WebAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infra.Repositories.Others;

public class CityRepository : ICityRepository
{
    private readonly WebAPIContext _context;
    private readonly IGenericRepository<City> _iCityRepository;

    public CityRepository(IGenericRepository<City> iCityRepository, WebAPIContext context)
    {
        _iCityRepository = iCityRepository;
        _context = context;
    }

    public IQueryable<City> GetAll(bool hasTracking = false)
    {
        return _iCityRepository.GetAll(hasTracking);
    }

    public IQueryable<City> FindBy(Expression<Func<City, bool>> predicate, bool hasTracking = false)
    {
        return _iCityRepository.FindBy(predicate, hasTracking);
    }

    public void Add(City city)
    {
        _iCityRepository.Create(city);
    }

    public void Update(City city)
    {
        _iCityRepository.Update(city);
    }

    public City GetById(long id)
    {
        return _iCityRepository.GetById(id);
    }

    public bool Exist(Expression<Func<City, bool>> predicate)
    {
        return _iCityRepository.Exist(predicate);
    }

    public void Remove(City city)
    {
        _iCityRepository.Remove(city);
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
