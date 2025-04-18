using FastPackForShare.Default;
using FastPackForShare.Extensions;
using FastPackForShare.Interfaces;
using FastPackForShare.Services.Bases;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services;

public sealed class StatesService : BaseHandlerService, IStatesService
{
    private readonly IStatesRepository _iStatesRepository;
    private readonly ICityService _iCityService;
    private readonly IMapperService _iMapperService;

    public StatesService(
        IStatesRepository iStatesRepository,
        ICityService iCityService,
        IMapperService iMapperService,
        INotificationMessageService iNotificationMessageService)
        : base(iNotificationMessageService)
    {
        _iStatesRepository = iStatesRepository;
        _iCityService = iCityService;
        _iMapperService = iMapperService;
    }

    public Task CreateStatesAsync(IEnumerable<States> list)
    {
        _iStatesRepository.AddRange(list);
        return Task.CompletedTask;
    }

    public async Task<long> GetStateByInitialsAsync(string initials)
    {
        var state = await _iStatesRepository.GetAll().FirstOrDefaultAsync(x => x.Initials == initials);
        return GuardClauseExtension.IsNotNull(state) ? state.Id.Value : 0;
    }

    public async Task<List<States>> GetAllStateAsync()
    {
        return await _iStatesRepository.GetAll().ToListAsync();
    }

    public async Task RefreshStatesAsync(RefreshStates refreshStates)
    {
        foreach (var item in refreshStates.ListStateAPI)
        {
            States state = refreshStates.ListState.FirstOrDefault(x => x.Initials == item.Initials && x.IsActive == true);
            if (GuardClauseExtension.IsNotNull(state))
            {
                state.UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
                state.Name = item.Name;
                state.Initials = item.Initials;
                _iStatesRepository.Update(state);
            }
            else
            {
                state = new States();
                state.IsActive = true;
                state.Name = item.Name;
                state.Initials = item.Initials;
                state.RegionId = refreshStates.ListRegion.FirstOrDefault(x => x.Initials == item.Region.Initials).Id ?? 0;
                _iStatesRepository.Add(state);
            }
        }
    }

    public async Task<bool> UpdateStateStatusByIdAsync(long id)
    {
        States record = await Task.FromResult(_iStatesRepository.GetById(id));

        if (GuardClauseExtension.IsNotNull(record))
        {
            record.IsActive = record.IsActive == true ? false : true;
            _iStatesRepository.Update(record);
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<States>> GetAllStateWithLikeAsync(string stateName) => await _iStatesRepository.FindBy(x => EF.Functions.Like(x.Name, $"%{stateName}%")).ToListAsync();

    public async Task<BasePagedResultModel<StatesResponseDTO>> GetAllStateWithPaginateAsync(StateFilter filter)
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
                              IsActive = x.IsActive
                          };

        var data = _iMapperService.ApplyMapToEntity<IEnumerable<States>, IEnumerable<StatesResponseDTO>>(queryResult);

        return BasePagedResultService.GetPaged(data.AsQueryable(), BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
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
               (GuardClauseExtension.IsNullOrWhiteSpace(filter.Name) || p.Name.StartsWith(filter.Name.ApplyTrim()));
    }
}
