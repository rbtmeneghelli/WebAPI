using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Application.Services;

public class CityService : GenericService, ICityService
{
    private readonly ICityRepository _iCityRepository;

    public CityService(ICityRepository iCityRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iCityRepository = iCityRepository;
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
            var queryResult = (from x in _iCityRepository.GetAll().AsQueryable().AsNoTracking()
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

    public async Task<IEnumerable<CityResponseDTO>> GetAllEntityAsync()
    {
        return await (from p in _iCityRepository.FindBy(x => true).AsQueryable()
                      orderby p.Name ascending
                      select new CityResponseDTO
                      {
                          Id = p.Id,
                          Name = p.Name,
                          IBGE = p.IBGE,
                          StateDesc = p.States.Initials,
                          IsActiveDesc = p.GetStatusDescription(),
                          IdState = p.StateId
                      }).ToListAsync();
    }

    public async Task<CityResponseDTO> GetByIdAsync(int id)
    {
        return await (from p in _iCityRepository.FindBy(x => x.Id == id).AsQueryable()
                      orderby p.Name ascending
                      select new CityResponseDTO
                      {
                          Id = p.Id,
                          Name = p.Name,
                          IBGE = p.IBGE,
                          StateDesc = p.States.Initials,
                          IsActiveDesc = p.GetStatusDescription(),
                          IdState = p.StateId
                      }).FirstOrDefaultAsync();
    }

    public Task AddAsync(City city)
    {
        _iCityRepository.Add(city);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(long id)
    {
        City city = _iCityRepository.GetById(id);

        if (GuardClauses.ObjectIsNotNull(city))
            _iCityRepository.Remove(city);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(City city)
    {
        City entityBase = _iCityRepository.FindBy(a => a.Id == city.Id).FirstOrDefault();

        if (GuardClauses.ObjectIsNotNull(entityBase))
        {
            entityBase.Name = city.Name;
            entityBase.IBGE = city.IBGE;
            entityBase.StateId = city.StateId;
            _iCityRepository.Update(entityBase);
        }

        _iCityRepository.Update(entityBase);
        return Task.CompletedTask;
    }

    public async Task<bool> AddOrUpdateCityAsync(IEnumerable<City> cities)
    {
        City entityBase = new City();
        try
        {
            List<City> citiesFromDatabase = await _iCityRepository.GetAll(true).ToListAsync();

            foreach (City city in cities)
            {
                if (citiesFromDatabase.Exists(x => x.IBGE == city.IBGE && x.StateId == city.StateId) == false)
                {
                    entityBase = new City();
                    entityBase.Name = city.Name;
                    entityBase.IBGE = city.IBGE.HasValue ? city.IBGE.Value : long.Parse("00000000");
                    entityBase.StateId = city.StateId;
                    _iCityRepository.Add(entityBase);
                }
                else
                {
                    _iCityRepository.ExecuteUpdate(city);
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
        return await Task.FromResult(_iCityRepository.Exist(a => a.Name == city && a.StateId == idState));
    }
}