using System.Linq.Expressions;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IRegionService
{
    Task AddRegionsAsync(IEnumerable<Region> list);

    Task<IEnumerable<Region>> GetAllRegionAsync();

    Task RefreshRegionAsync(IEnumerable<States> listStatesAPI);

    Task<bool> UpdateStatusByIdAsync(long id);

    Task<IEnumerable<Region>> GetAllWithLikeAsync(string parameter);

    Task<PagedResult<Region>> GetAllWithPaginateAsync(RegionFilter filter);
    bool ExistRegionById(long regionId);
    long GetCount(Expression<Func<Region, bool>> predicate);
    bool ExistRegion();
    Task<Region> Add(Region region);
    Task<Region> Update(Region region);
    Task Delete(Region region);
    Task<IQueryable<Region>> GetQueryAbleRegionAsync();
}
