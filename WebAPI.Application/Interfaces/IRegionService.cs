namespace WebAPI.Application.Interfaces
{
    public interface IRegionService
    {
        Task AddRegionsAsync(List<Region> list);

        Task<List<Region>> GetAllRegionAsync();

        Task RefreshRegionAsync(List<States> listStatesAPI);

        Task<bool> UpdateStatusByIdAsync(long id);

        Task<List<Region>> GetAllWithLikeAsync(string parametro);

        Task<PagedResult<Region>> GetAllWithPaginateAsync(RegionFilter filter);
        bool ExistRegionById(long regionId);
        long GetCount(Expression<Func<Region, bool>> predicate);
    }
}
