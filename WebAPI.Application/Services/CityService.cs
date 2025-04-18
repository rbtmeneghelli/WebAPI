using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Application.Services;

public sealed class CityService : BaseHandlerService, ICityService
{
    private readonly ICityRepository _iCityRepository;

    public CityService(ICityRepository iCityRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iCityRepository = iCityRepository;
    }

    public async Task<IEnumerable<long>> GetCityByIdStatesAsync()
    {
        var list = await GetAllCityEntityAsync();
        return (from x in list select x.IdState.Value).Distinct();
    }

    public async Task<BasePagedResultModel<CityResponseDTO>> GetAllCityFromUfAsync(int idState = 25, int? page = 1, int? limit = int.MaxValue)
    {
        var queryResult = (from x in _iCityRepository.GetAll().AsQueryable()
                           where x.StateId == idState
                           orderby x.Name ascending
                           select new CityResponseDTO()
                           {
                               Id = x.Id,
                               Name = x.Name
                           });

        return BasePagedResultService.GetPaged(queryResult, BasePagedResultService.GetDefaultPageIndex(page), BasePagedResultService.GetDefaultPageSize(limit));
    }

    public async Task<IEnumerable<CityResponseDTO>> GetAllCityEntityAsync()
    {
        return await (from p in _iCityRepository.FindBy(x => true).AsQueryable()
                      orderby p.Name ascending
                      select new CityResponseDTO
                      {
                          Id = p.Id,
                          Name = p.Name,
                          IBGE = p.IBGE,
                          StateDesc = p.States.Initials,
                          IsActiveDesc = p.IsActive.GetDescriptionByBoolean(),
                          IdState = p.StateId
                      }).ToListAsync();
    }

    public async Task<CityResponseDTO> GetCityByIdAsync(int id)
    {
        return await (from p in _iCityRepository.FindBy(x => x.Id == id).AsQueryable()
                      orderby p.Name ascending
                      select new CityResponseDTO
                      {
                          Id = p.Id,
                          Name = p.Name,
                          IBGE = p.IBGE,
                          StateDesc = p.States.Initials,
                          IsActiveDesc = p.IsActive.GetDescriptionByBoolean(),
                          IdState = p.StateId
                      }).FirstOrDefaultAsync();
    }

    public Task CreateCityAsync(City city)
    {
        _iCityRepository.Add(city);
        return Task.CompletedTask;
    }

    public Task DeleteCityAsync(long id)
    {
        City city = _iCityRepository.GetById(id);

        if (GuardClauseExtension.IsNotNull(city))
            _iCityRepository.Remove(city);

        return Task.CompletedTask;
    }

    public Task UpdateCityAsync(City city)
    {
        City entityBase = _iCityRepository.FindBy(a => a.Id == city.Id).FirstOrDefault();

        if (GuardClauseExtension.IsNotNull(entityBase))
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

    public async Task<bool> ExistCityByCityIdStateAsync(string city, long idState)
    {
        return await Task.FromResult(_iCityRepository.Exist(a => a.Name == city && a.StateId == idState));
    }
}