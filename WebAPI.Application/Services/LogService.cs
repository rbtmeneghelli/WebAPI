using WebAPI.Application.Factory;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services;

public class LogService : GenericService, ILogService
{
    private readonly ILogRepository _iLogRepository;

    public LogService(ILogRepository iLogRepository, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iLogRepository = iLogRepository;
    }

    private async Task<IQueryable<Log>> GetAllWithFilterAsync(LogFilter filter)
    {
        return await Task.FromResult(_iLogRepository.GetAll().Where(GetPredicateAsync(filter)).AsQueryable());
    }

    private async Task<int> GetCountAsync(LogFilter filter)
    {
        return await _iLogRepository.GetAll().CountAsync(GetPredicateAsync(filter));
    }

    private Expression<Func<Log, bool>> GetPredicateAsync(LogFilter filter)
    {
        return p =>
        (GuardClauses.IsNullOrWhiteSpace(filter.Class) || p.Class.StartsWith(filter.Class.ApplyTrim()));
    }

    public async Task<Log> GetLogByIdAsync(long id)
    {
        return await Task.FromResult(_iLogRepository.GetById(id));
    }

    public async Task<IEnumerable<Log>> GetAllLogWithLikeAsync(string parameter) => await _iLogRepository.FindBy(x => EF.Functions.Like(x.Class, $"%{parameter}%")).ToListAsync();

    public async Task<PagedResult<LogResponseDTO>> GetAllLogPaginateAsync(LogFilter filter)
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

            return PagedFactory.GetPaged(queryResult, PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETALL);
            return PagedFactory.GetPaged(Enumerable.Empty<LogResponseDTO>().AsQueryable(), PagedFactory.GetDefaultPageIndex(filter.PageIndex), PagedFactory.GetDefaultPageSize(filter.PageSize));
        }
    }

    public async Task<bool> ExistLogByIdAsync(long id)
    {
        try
        {
            var result = _iLogRepository.Exist(x => x.Id == id);

            if (result == false)
                Notify(FixConstants.ERROR_IN_GETID);

            return result;
        }
        catch
        {
            Notify(FixConstants.ERROR_IN_GETID);
            return false;
        }
        finally
        {
            await Task.CompletedTask;
        }
    }
}
