﻿using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface ICityService
{
    Task<PagedResult<CityResponseDTO>> GetAllCityFromUfAsync(int idState = 25, int? page = 1, int? limit = int.MaxValue);
    Task<IEnumerable<CityResponseDTO>> GetAllCityEntityAsync();
    Task<CityResponseDTO> GetCityByIdAsync(int id);
    Task CreateCityAsync(City city);
    Task UpdateCityAsync(City city);
    Task DeleteCityAsync(long id);
    Task<bool> AddOrUpdateCityAsync(IEnumerable<City> cities);
    Task<bool> ExistCityByCityIdStateAsync(string city, long idState);
    Task<IEnumerable<long>> GetCityByIdStatesAsync();
}
