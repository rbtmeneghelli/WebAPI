using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public record AuditFilter : BaseFilterModel
{
    public string TableName { get; set; }
}
