using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface ILogService
{
    Task<LogResponseDTO> GetLogByIdAsync(long id);
    Task<IEnumerable<Log>> GetAllLogWithLikeAsync(string parameter);
    Task<PagedResult<LogResponseDTO>> GetAllLogPaginateAsync(LogFilter filter);
    Task<bool> ExistLogByIdAsync(long id);
}
