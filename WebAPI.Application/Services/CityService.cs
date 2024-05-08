using WebAPI.Application.Factory;
using System.Collections.Generic;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.Services;

public class CityService : GenericService, ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository, INotificationMessageService notificationMessageService) : base(notificationMessageService)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IEnumerable<long>> GetIdStatesAsync()
    {
        var list = await GetAllEntityAsync();
        return (from x in list select x.IdState.Value).Distinct();
    }

    public async Task<PagedResult<CityResponseDTO>> GetAllFromUfAsync(int idState = 25, int? page = 1, int? limit = int.MaxValue)
    {
        try
        {
            var queryResult = (from x in _cityRepository.GetAll().AsQueryable().AsNoTracking()
                               where x.StateId == idState
                               orderby x.Name ascending
                               select new CityResponseDTO()
                               {
                                   Id = x.Id,
                                   Name = x.Name
                               });

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(page), PagedFactory.GetDefaultPageSize(limit));
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return PagedFactory.GetPaged(Enumerable.Empty<CityResponseDTO>().AsQueryable(), PagedFactory.GetDefaultPageIndex(page), PagedFactory.GetDefaultPageSize(limit));
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<List<CityResponseDTO>> GetAllEntityAsync()
    {
        return await (from p in _cityRepository.FindBy(x => true).AsQueryable()
                      orderby p.Name ascending
                      select new CityResponseDTO
                      {
                          Id = p.Id,
                          Name = p.Name,
                          IBGE = p.IBGE,
                          StateDesc = p.States.Initials,
                          IsActiveDesc = p.GetStatus(),
                          IdState = p.StateId
                      }).ToListAsync();
    }

    public async Task<CityResponseDTO> GetByIdAsync(int id)
    {
        return await (from p in _cityRepository.FindBy(x => x.Id == id).AsQueryable()
                      orderby p.Name ascending
                      select new CityResponseDTO
                      {
                          Id = p.Id,
                          Name = p.Name,
                          IBGE = p.IBGE,
                          StateDesc = p.States.Initials,
                          IsActiveDesc = p.GetStatus(),
                          IdState = p.StateId
                      }).FirstOrDefaultAsync();
    }

    public Task AddAsync(City city)
    {
        city.CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        _cityRepository.Add(city);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(long id)
    {
        City city = _cityRepository.GetById(id);

        if (GuardClauses.ObjectIsNotNull(city))
            _cityRepository.Remove(city);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(City city)
    {
        City entityBase = _cityRepository.FindBy(a => a.Id == city.Id).FirstOrDefault();

        if (GuardClauses.ObjectIsNotNull(entityBase))
        {
            entityBase.Name = city.Name;
            entityBase.IBGE = city.IBGE;
            entityBase.StateId = city.StateId;
            _cityRepository.Update(entityBase);
        }

        _cityRepository.Update(entityBase);
        return Task.CompletedTask;
    }

    public async Task<bool> AddOrUpdateCityAsync(List<City> cities)
    {
        City entityBase = new City();
        try
        {
            List<City> citiesFromDatabase = await _cityRepository.GetAll(true).ToListAsync();

            foreach (City city in cities)
            {
                if (citiesFromDatabase.Exists(x => x.IBGE == city.IBGE && x.StateId == city.StateId) == false)
                {
                    entityBase = new City();
                    entityBase.Name = city.Name;
                    entityBase.IBGE = city.IBGE.HasValue ? city.IBGE.Value : long.Parse("00000000");
                    entityBase.StateId = city.StateId;
                    entityBase.CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                    _cityRepository.Add(entityBase);
                }
                else
                {
                    _cityRepository.ExecuteUpdate(city);
                }
            }

            return true;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_ADDCITY);
            return false;
        }
    }

    public async Task<bool> CheckCityExistAsync(string city, long idState)
    {
        return await Task.FromResult(_cityRepository.Exist(a => a.Name == city && a.StateId == idState));
    }
}