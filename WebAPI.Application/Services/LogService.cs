using WebAPI.Application.Factory;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.Services
{
    public class LogService : GenericService, ILogService
    {
        public readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository, INotificationMessageService notificationMessageService) : base(notificationMessageService)
        {
            _logRepository = logRepository;
        }

        private async Task<IQueryable<Log>> GetAllWithFilterAsync(LogFilter filter)
        {
            return await Task.FromResult(_logRepository.GetAll().Where(GetPredicateAsync(filter)).AsQueryable());
        }

        private async Task<int> GetCountAsync(LogFilter filter)
        {
            return await _logRepository.GetAll().CountAsync(GetPredicateAsync(filter));
        }

        private Expression<Func<Log, bool>> GetPredicateAsync(LogFilter filter)
        {
            return p =>
            (GuardClauses.IsNullOrWhiteSpace(filter.Class) || p.Class.StartsWith(filter.Class.ApplyTrim()));
        }

        public async Task<Log> GetByIdAsync(long id)
        {
            return await Task.FromResult(_logRepository.GetById(id));
        }

        public async Task<List<Log>> GetAllWithLikeAsync(string parametro) => await _logRepository.FindBy(x => EF.Functions.Like(x.Class, $"%{parametro}%")).ToListAsync();

        public async Task<PagedResult<LogResponseDTO>> GetAllPaginateAsync(LogFilter filter)
        {
            try
            {
                var query = await GetAllWithFilterAsync(filter);
                var queryCount = await GetCountAsync(filter);

                var queryResult = from x in query.AsQueryable()
                                  orderby x.UpdateTime descending
                                  select new LogResponseDTO()
                                  {
                                      Id = x.Id,
                                      Class = x.Class,
                                      Method = x.Method,
                                      Object = x.Object,
                                      MessageError = x.MessageError,
                                      UpdateTime = x.UpdateTime
                                  };

                return PagedFactory.GetPaged(queryResult, filter.PageIndex, filter.PageSize);
            }
            catch
            {
                Notify(Constants.ERROR_IN_GETALL);
                return PagedFactory.GetPaged(Enumerable.Empty<LogResponseDTO>().AsQueryable(), filter.PageIndex, filter.PageSize);
            }
        }

        public async Task<bool> ExistByIdAsync(long id)
        {
            try
            {
                var result = _logRepository.Exist(x => x.Id == id);

                if (result == false)
                    Notify(Constants.ERROR_IN_GETID);

                return result;
            }
            catch
            {
                Notify(Constants.ERROR_IN_GETID);
                return false;
            }
            finally
            {
                await Task.CompletedTask;
            }
        }
    }
}
