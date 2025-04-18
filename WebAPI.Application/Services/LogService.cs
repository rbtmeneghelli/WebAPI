using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services;

public sealed class LogService : BaseHandlerService, ILogService
{
    private readonly ILogRepository _iLogRepository;
    private readonly IMapperService _iMapperService;

    public LogService(ILogRepository iLogRepository, INotificationMessageService iNotificationMessageService, IMapperService iMapperService) : base(iNotificationMessageService)
    {
        _iLogRepository = iLogRepository;
        _iMapperService = iMapperService;
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
        (GuardClauseExtension.IsNullOrWhiteSpace(filter.Class) || p.Class.StartsWith(filter.Class.ApplyTrim()));
    }

    public async Task<LogResponseDTO> GetLogByIdAsync(long id)
    {
        var data = await Task.FromResult(_iLogRepository.GetById(id));
        return _iMapperService.ApplyMapToEntity<Log, LogResponseDTO>(data);
    }

    public async Task<IEnumerable<Log>> GetAllLogWithLikeAsync(string parameter) => await _iLogRepository.FindBy(x => EF.Functions.Like(x.Class, $"%{parameter}%")).ToListAsync();

    public async Task<BasePagedResultModel<LogResponseDTO>> GetAllLogPaginateAsync(LogFilter filter)
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

        return BasePagedResultService.GetPaged(queryResult, BasePagedResultService.GetDefaultPageIndex(filter.PageIndex), BasePagedResultService.GetDefaultPageSize(filter.PageSize));
    }

    public async Task<bool> ExistLogByIdAsync(long id)
    {
        var result = _iLogRepository.Exist(x => x.Id == id);

        if (result == false)
            Notify(FixConstants.ERROR_IN_GETID);

        return result;
    }
}
