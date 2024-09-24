using System.Linq.Expressions;
using WebAPI.Application.Generic;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Infra.Repositories.Others;

public class RegionRepository : IRegionRepository
{
    private readonly IGenericRepository<Region> _iRegionRepository;

    public RegionRepository(IGenericRepository<Region> iRegionRepository)
    {
        _iRegionRepository = iRegionRepository;
    }

    public void Add(Region region)
    {
        _iRegionRepository.Create(region);
    }

    public bool Exist(Expression<Func<Region, bool>> predicate)
    {
        return _iRegionRepository.Exist(predicate);
    }

    public IQueryable<Region> FindBy(Expression<Func<Region, bool>> predicate, bool hasTracking = false)
    {
        return _iRegionRepository.FindBy(predicate, hasTracking);
    }

    public IQueryable<Region> GetAll(bool hasTracking = false)
    {
        return _iRegionRepository.GetAll(hasTracking);
    }

    public Region GetById(long id)
    {
        return _iRegionRepository.GetById(id);
    }

    public void Remove(Region region)
    {
        _iRegionRepository.Remove(region);
    }

    public void Update(Region region)
    {
        _iRegionRepository.Update(region);
    }

    public void AddRange(IEnumerable<Region> regions)
    {
        _iRegionRepository.AddRange(regions);
    }

    public long GetCount(Expression<Func<Region, bool>> predicate)
    {
        return _iRegionRepository.GetCount(predicate);
    }
}
