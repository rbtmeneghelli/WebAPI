using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Interfaces;

public interface ILogService
{
    Task<Log> GetByIdAsync(long id);
    Task<IEnumerable<Log>> GetAllWithLikeAsync(string parameter);
    Task<PagedResult<LogResponseDTO>> GetAllPaginateAsync(LogFilter filter);
    Task<bool> ExistByIdAsync(long id);
}
