using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.Others;

public class AuditFilter : GenericFilter
{
    public string TableName { get; set; }
}
