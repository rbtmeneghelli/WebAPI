namespace WebAPI.Application.Interfaces;

public interface IAuditService
{
    Task<Audit> GetByIdAsync(long id);
    Task<List<Audit>> GetAllWithLikeAsync(string parametro);
    Task<PagedResult<AuditResponseDTO>> GetAllPaginateAsync(AuditFilter filter);
    Task<bool> ExistByIdAsync(long id);
    Task CreateAuditBySQLScript(Audit audit);
}
