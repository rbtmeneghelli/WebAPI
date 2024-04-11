using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class AuditFilter : GenericFilter
{
    public string TableName { get; set; }
}
