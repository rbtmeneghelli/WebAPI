using WebAPI.Application;
using WebAPI.Application.Interfaces;
using WebAPI.Domain;
using WebAPI.Domain.Entities;
using WebAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Infra.Data.Repositories;

public class CityRepository : ICityRepository
{
    private readonly WebAPIContext _context;
    private readonly IGenericRepository<City> _repository;

    public CityRepository(IGenericRepository<City> repository, WebAPIContext context)
    {
        _repository = repository;
        _context = context;
    }

    public IQueryable<City> GetAll(bool hasTracking = false)
    {
        return _repository.GetAll(hasTracking);
    }

    public IQueryable<City> FindBy(Expression<Func<City, bool>> predicate, bool hasTracking = false)
    {
        return _repository.FindBy(predicate, hasTracking);
    }

    public void Add(City city)
    {
        _repository.Add(city);
    }

    public void Update(City city)
    {
        _repository.Update(city);
    }

    public City GetById(long id)
    {
        return _repository.GetById(id);
    }

    public bool Exist(Expression<Func<City, bool>> predicate)
    {
        return _repository.Exist(predicate);
    }

    public void Remove(City city)
    {
        _repository.Remove(city);
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
                .SetProperty(p => p.IsActive, true)
                .SetProperty(p => p.UpdateTime, DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()));
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
