namespace WebAPI.Application.Interfaces;

public interface ILogService
{
    Task<Log> GetByIdAsync(long id);
    Task<List<Log>> GetAllWithLikeAsync(string parametro);
    Task<PagedResult<LogResponseDTO>> GetAllPaginateAsync(LogFilter filter);
    Task<bool> ExistByIdAsync(long id);
}
