using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.ControlPanel;

public class EmployeeFilter : GenericFilter
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelPhone { get; set; }
    public string CelPhone { get; set; }
    public long IdProfile { get; set; }
}

