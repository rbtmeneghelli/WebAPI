using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class EmployeeFilter : GenericFilter
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelPhone { get; set; }
    public string CelPhone { get; set; }
    public long IdProfile { get; set; }
}

