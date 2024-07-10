namespace WebAPI.Application.Interfaces
{
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
    }
}
