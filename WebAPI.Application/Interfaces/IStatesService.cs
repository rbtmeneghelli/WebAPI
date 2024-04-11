namespace WebAPI.Application.Interfaces
{
    public interface IStatesService
    {
        Task AddStatesAsync(List<States> list);
        Task<long> GetStateByInitialsAsync(string initials);
        Task<List<States>> GetAllStatesAsync();
        Task RefreshStatesAsync(RefreshStates refreshStates);
        Task<bool> UpdateStatusByIdAsync(long id);
        Task<List<States>> GetAllWithLikeAsync(string param);
        Task<PagedResult<States>> GetAllWithPaginateAsync(StateFilter filter);
    }
}
