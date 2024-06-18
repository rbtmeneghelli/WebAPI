using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.Services
{
    public class StatesService : GenericService, IStatesService
    {
        public readonly IStatesRepository _stateRepository;

        public StatesService(IStatesRepository stateRepository, INotificationMessageService notificationMessageService) : base(notificationMessageService)
        {
            _stateRepository = stateRepository;
        }

        private async Task<IQueryable<States>> GetAllWithFilterAsync(StateFilter filter)
        {
            return await Task.FromResult(_stateRepository.GetAll().Where(GetPredicate(filter)).AsQueryable());
        }

        private async Task<int> GetCountAsync(StateFilter filter)
        {
            return await _stateRepository.GetAll().CountAsync(GetPredicate(filter));
        }

        private Expression<Func<States, bool>> GetPredicate(StateFilter filter)
        {
            return p =>
                   (GuardClauses.IsNullOrWhiteSpace(filter.Nome) || p.Name.StartsWith(filter.Nome.ApplyTrim()));
        }

        public Task AddStatesAsync(IEnumerable<States> list)
        {
            _stateRepository.AddRange(list);
            return Task.CompletedTask;
        }

        public async Task<long> GetStateByInitialsAsync(string initials)
        {
            var state = await _stateRepository.GetAll().FirstOrDefaultAsync(x => x.Initials == initials);
            return GuardClauses.ObjectIsNotNull(state) ? state.Id.Value : 0;
        }

        public async Task<List<States>> GetAllStatesAsync()
        {
            return await _stateRepository.GetAll().ToListAsync();
        }

        public async Task RefreshStatesAsync(RefreshStates refreshStates)
        {
            try
            {
                foreach (var item in refreshStates.ListStateAPI)
                {
                    States state = refreshStates.ListState.FirstOrDefault(x => x.Initials == item.Initials && x.IsActive == true);
                    if (GuardClauses.ObjectIsNotNull(state))
                    {
                        state.UpdateTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                        state.Name = item.Name;
                        state.Initials = item.Initials;
                        _stateRepository.Update(state);
                    }
                    else
                    {
                        state = new States();
                        state.IsActive = true;
                        state.CreatedTime = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
                        state.Name = item.Name;
                        state.Initials = item.Initials;
                        state.RegionId = refreshStates.ListRegion.FirstOrDefault(x => x.Initials == item.Region.Initials).Id ?? 0;
                        _stateRepository.Add(state);
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

        public async Task<bool> UpdateStatusByIdAsync(long id)
        {
            try
            {
                States record = await Task.FromResult(_stateRepository.GetById(id));
                if (GuardClauses.ObjectIsNotNull(record))
                {
                    record.IsActive = record.IsActive == true ? false : true;
                    _stateRepository.Update(record);
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

        public async Task<IEnumerable<States>> GetAllWithLikeAsync(string stateName) => await _stateRepository.FindBy(x => EF.Functions.Like(x.Name, $"%{stateName}%")).ToListAsync();

        public async Task<PagedResult<States>> GetAllWithPaginateAsync(StateFilter filter)
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
                                      IsActive = x.IsActive
                                  };

                return PagedFactory.GetPaged(queryResult, filter.PageIndex, filter.PageSize);
            }
            catch
            {
                Notify(FixConstants.ERROR_IN_GETALL);
                return PagedFactory.GetPaged(Enumerable.Empty<States>().AsQueryable(), filter.PageIndex, filter.PageSize);
            }
        }
    }
}
