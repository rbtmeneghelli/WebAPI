using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IRegionService
{
    Task CreateRegionsAsync(IEnumerable<Region> list);

    Task<IEnumerable<Region>> GetAllRegionAsync();

    Task RefreshRegionAsync(IEnumerable<States> listStatesAPI);

    Task<bool> UpdateRegionStatusByIdAsync(long id);

    Task<IEnumerable<Region>> GetAllRegionWithLikeAsync(string parameter);

    Task<PagedResult<Region>> GetAllRegionWithPaginateAsync(RegionFilter filter);
    bool ExistRegionById(long regionId);
    long GetRegionCount(Expression<Func<Region, bool>> predicate);
    bool ExistRegion();
    Task<Region> CreateRegion(Region region);
    Task<Region> UpdateRegion(Region region);
    Task DeleteRegion(Region region);
    Task<IQueryable<Region>> GetQueryAbleRegionAsync();
    Region GetRegionById(long id);
}
