using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface ICityService
{
    Task<PagedResult<CityResponseDTO>> GetAllFromUfAsync(int idState = 25, int? page = 1, int? limit = int.MaxValue);
    Task<IEnumerable<CityResponseDTO>> GetAllEntityAsync();
    Task<CityResponseDTO> GetByIdAsync(int id);
    Task AddAsync(City city);
    Task RemoveAsync(long id);
    Task UpdateAsync(City city);
    Task<bool> AddOrUpdateCityAsync(IEnumerable<City> cities);
    Task<bool> CheckCityExistAsync(string city, long idState);
    Task<IEnumerable<long>> GetIdStatesAsync();
}
