using FastPackForShare.Default;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IStatesService
{
    Task CreateStatesAsync(IEnumerable<States> list);
    Task<long> GetStateByInitialsAsync(string initials);
    Task<List<States>> GetAllStateAsync();
    Task RefreshStatesAsync(RefreshStates refreshStates);
    Task<bool> UpdateStateStatusByIdAsync(long id);
    Task<IEnumerable<States>> GetAllStateWithLikeAsync(string param);
    Task<BasePagedResultModel<StatesResponseDTO>> GetAllStateWithPaginateAsync(StateFilter filter);
    Task<List<States>> GetListStateWithoutCities();
}

