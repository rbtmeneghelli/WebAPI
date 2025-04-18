using FastPackForShare.Default;
using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.Others;

public sealed record AuditFilter : BaseFilterModel
{
    public string TableName { get; set; }
}
