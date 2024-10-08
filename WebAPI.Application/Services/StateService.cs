using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services;

public class StatesService : GenericService, IStatesService
{
    private readonly IStatesRepository _iStatesRepository;
    private readonly ICityService _iCityService;

    public StatesService(
        IStatesRepository iStatesRepository,
        ICityService iCityService,
        INotificationMessageService iNotificationMessageService) 
        : base(iNotificationMessageService)
    {
        _iStatesRepository = iStatesRepository;
        _iCityService = iCityService;
    }

    public Task CreateStatesAsync(IEnumerable<States> list)
    {
        _iStatesRepository.AddRange(list);
        return Task.CompletedTask;
    }

    public async Task<long> GetStateByInitialsAsync(string initials)
    {
        var state = await _iStatesRepository.GetAll().FirstOrDefaultAsync(x => x.Initials == initials);
        return GuardClauses.ObjectIsNotNull(state) ? state.Id.Value : 0;
    }

    public async Task<List<States>> GetAllStateAsync()
    {
        return await _iStatesRepository.GetAll().ToListAsync();
    }

    public async Task RefreshStatesAsync(RefreshStates refreshStates)
    {
        try
        {
            foreach (var item in refreshStates.ListStateAPI)
            {
                States state = refreshStates.ListState.FirstOrDefault(x => x.Initials == item.Initials && x.Status == true);
                if (GuardClauses.ObjectIsNotNull(state))
                {
                    state.UpdateDate = state.GetNewUpdateDate();
                    state.Name = item.Name;
                    state.Initials = item.Initials;
                    _iStatesRepository.Update(state);
                }
                else
                {
                    state = new States();
                    state.Status = true;
                    state.Name = item.Name;
                    state.Initials = item.Initials;
                    state.RegionId = refreshStates.ListRegion.FirstOrDefault(x => x.Initials == item.Region.Initials).Id ?? 0;
                    _iStatesRepository.Add(state);
                }
            }
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_REFRESHSTATE);
        }
        finally
        {
            await Task.CompletedTask;
        }
    }

    public async Task<bool> UpdateStateStatusByIdAsync(long id)
    {
        try
        {
            States record = await Task.FromResult(_iStatesRepository.GetById(id));
            if (GuardClauses.ObjectIsNotNull(record))
            {
                record.Status = record.Status == true ? false : true;
                _iStatesRepository.Update(record);
                return true;
            }
            return false;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_UPDATESTATUS);
            return false;
        }
    }

    public async Task<IEnumerable<States>> GetAllStateWithLikeAsync(string stateName) => await _iStatesRepository.FindBy(x => EF.Functions.Like(x.Name, $"%{stateName}%")).ToListAsync();

    public async Task<PagedResult<States>> GetAllStateWithPaginateAsync(StateFilter filter)
    {
        try
        {
            var query = await GetAllWithFilterAsync(filter);
            var queryCount = await GetCountAsync(filter);

            var queryResult = from x in query.AsQueryable()
                              orderby x.Name ascending
                              select new States
                              {
                                  Id = x.Id,
                                  Name = x.Name,
                                  Initials = x.Initials,
                                  Status = x.Status
                              };

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return PagedFactory.GetPaged(Enumerable.Empty<States>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
    }

    public async Task<List<States>> GetListStateWithoutCities()
    {
        List<States> listState = await GetAllStateAsync();

        if (listState is not null)
        {
            IEnumerable<long> listIdState = await _iCityService.GetCityByIdStatesAsync();
            foreach (long idState in listIdState)
            {
                listState.RemoveAll(x => x.Id == idState);
            }
        }
        return listState;
    }

    private async Task<IQueryable<States>> GetAllWithFilterAsync(StateFilter filter)
    {
        return await Task.FromResult(_iStatesRepository.GetAll().Where(GetPredicate(filter)).AsQueryable());
    }

    private async Task<int> GetCountAsync(StateFilter filter)
    {
        return await _iStatesRepository.GetAll().CountAsync(GetPredicate(filter));
    }

    private Expression<Func<States, bool>> GetPredicate(StateFilter filter)
    {
        return p =>
               (GuardClauses.IsNullOrWhiteSpace(filter.Nome) || p.Name.StartsWith(filter.Nome.ApplyTrim()));
    }
}
