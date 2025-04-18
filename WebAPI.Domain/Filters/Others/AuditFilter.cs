using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public sealed record AuditFilter : BaseFilterModel
{
    public string TableName { get; set; }
}
