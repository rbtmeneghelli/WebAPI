namespace WebAPI.Application.Interfaces;

public interface IAuditService
{
    Task<Audit> GetByIdAsync(long id);
    Task<IEnumerable<Audit>> GetAllWithLikeAsync(string parameter);
    Task<PagedResult<AuditResponseDTO>> GetAllPaginateAsync(AuditFilter filter);
    Task<bool> ExistByIdAsync(long id);
    Task CreateAuditBySQLScript(Audit audit);
}
