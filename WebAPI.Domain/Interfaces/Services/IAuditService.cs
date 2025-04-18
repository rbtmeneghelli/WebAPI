using WebAPI.Domain.Entities.Others;
using WebAPI.Domain.DTO.Others;
using WebAPI.Domain.Filters.Others;
using FastPackForShare.Default;

namespace WebAPI.Domain.Interfaces.Services;

public interface IAuditService
{
    Task<AuditResponseDTO> GetAuditByIdAsync(long id);
    Task<IEnumerable<Audit>> GetAllAuditWithLikeAsync(string parameter);
    Task<BasePagedResultModel<AuditResponseDTO>> GetAllAuditPaginateAsync(AuditFilter filter);
    Task<bool> ExistAuditByIdAsync(long id);
    Task CreateAuditBySQLScript(Audit audit);
    Task CreateAuditByDapper(Audit audit);
    Task UpdateAuditByDapper(Audit audit);
    Task DeleteAuditByDapper(Audit audit, bool isLogicDelete = true);
    Task ReactiveAuditByDapper(Audit audit);
}
