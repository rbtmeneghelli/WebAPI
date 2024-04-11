namespace WebAPI.Application.Interfaces;

public interface ICityService
{
    Task<PagedResult<CityResponseDTO>> GetAllFromUfAsync(int idState = 25, int? page = 1, int? limit = int.MaxValue);
    Task<List<CityResponseDTO>> GetAllEntityAsync();
    Task<CityResponseDTO> GetByIdAsync(int id);
    Task AddAsync(City city);
    Task RemoveAsync(long id);
    Task UpdateAsync(City city);
    Task<bool> AddOrUpdateCityAsync(List<City> cities);
    Task<bool> CheckCityExistAsync(string city, long idState);
    Task<IEnumerable<long>> GetIdStatesAsync();
}
