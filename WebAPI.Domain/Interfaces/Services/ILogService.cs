using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
using FastPackForShare.Default;

namespace WebAPI.Domain.Interfaces.Services;

public interface ILogService
{
    Task<LogResponseDTO> GetLogByIdAsync(long id);
    Task<IEnumerable<Log>> GetAllLogWithLikeAsync(string parameter);
    Task<BasePagedResultModel<LogResponseDTO>> GetAllLogPaginateAsync(LogFilter filter);
    Task<bool> ExistLogByIdAsync(long id);
}
