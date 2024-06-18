namespace WebAPI.Application.Interfaces;

public interface ILogService
{
    Task<Log> GetByIdAsync(long id);
    Task<IEnumerable<Log>> GetAllWithLikeAsync(string parameter);
    Task<PagedResult<LogResponseDTO>> GetAllPaginateAsync(LogFilter filter);
    Task<bool> ExistByIdAsync(long id);
}
