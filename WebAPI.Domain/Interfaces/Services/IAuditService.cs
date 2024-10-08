using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.EntitiesDTO.Others;
using WebAPI.Domain.Filters.Others;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;

public interface IAuditService
{
    Task<Audit> GetAuditByIdAsync(long id);
    Task<IEnumerable<Audit>> GetAllAuditWithLikeAsync(string parameter);
    Task<PagedResult<AuditResponseDTO>> GetAllAuditPaginateAsync(AuditFilter filter);
    Task<bool> ExistAuditByIdAsync(long id);
    Task CreateAuditBySQLScript(Audit audit);
    Task CreateAuditByDapper(Audit audit);
    Task UpdateAuditByDapper(Audit audit);
    Task DeleteAuditByDapper(Audit audit, bool isLogicDelete = true);
    Task ReactiveAuditByDapper(Audit audit);
}
