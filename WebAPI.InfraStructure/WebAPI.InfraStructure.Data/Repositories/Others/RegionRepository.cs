using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Generic;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.InfraStructure.Data.Repositories.Others;

public class RegionRepository : IRegionRepository
{
    private readonly IReadRepository<Region> _iRegionReadRepository;
    private readonly IWriteRepository<Region> _iRegionWriteRepository;

    public RegionRepository(
        IReadRepository<Region> iRegionReadRepository,
        IWriteRepository<Region> iRegionWriteRepository
    )
    {
        _iRegionReadRepository = iRegionReadRepository;
        _iRegionWriteRepository = iRegionWriteRepository;
    }

    public bool Exist(Expression<Func<Region, bool>> predicate)
    {
        return _iRegionReadRepository.Exist(predicate);
    }

    public IQueryable<Region> FindBy(Expression<Func<Region, bool>> predicate, bool hasTracking = false)
    {
        return _iRegionReadRepository.GetByPredicate(predicate, hasTracking);
    }

    public IQueryable<Region> GetAll(bool hasTracking = false)
    {
        return _iRegionReadRepository.GetAll(hasTracking);
    }

    public Region GetById(long id)
    {
        return _iRegionReadRepository.GetById(id);
    }

    public long GetCount(Expression<Func<Region, bool>> predicate)
    {
        return _iRegionReadRepository.GetCount(predicate);
    }

    public void Add(Region region)
    {
        _iRegionWriteRepository.Create(region);
    }

    public void AddRange(IEnumerable<Region> regions)
    {
        _iRegionWriteRepository.BulkCreate(regions);
    }

    public void Update(Region region)
    {
        _iRegionWriteRepository.Update(region);
    }

    public void Remove(Region region)
    {
        _iRegionWriteRepository.Remove(region);
    }
}
