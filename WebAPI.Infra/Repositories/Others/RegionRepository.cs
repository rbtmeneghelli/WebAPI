using System.Linq.Expressions;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Infra.Repositories.Others;

public class RegionRepository : IRegionRepository
{
    private readonly IGenericRepository<Region> _repository;

    public RegionRepository(IGenericRepository<Region> repository)
    {
        _repository = repository;
    }

    public void Add(Region region)
    {
        _repository.Add(region);
    }

    public bool Exist(Expression<Func<Region, bool>> predicate)
    {
        return _repository.Exist(predicate);
    }

    public IQueryable<Region> FindBy(Expression<Func<Region, bool>> predicate, bool hasTracking = false)
    {
        return _repository.FindBy(predicate, hasTracking);
    }

    public IQueryable<Region> GetAll(bool hasTracking = false)
    {
        return _repository.GetAll(hasTracking);
    }

    public Region GetById(long id)
    {
        return _repository.GetById(id);
    }

    public void Remove(Region region)
    {
        _repository.Remove(region);
    }

    public void Update(Region region)
    {
        _repository.Update(region);
    }

    public void AddRange(IEnumerable<Region> regions)
    {
        _repository.AddRange(regions);
    }

    public long GetCount(Expression<Func<Region, bool>> predicate)
    {
        return _repository.GetCount(predicate);
    }
}
