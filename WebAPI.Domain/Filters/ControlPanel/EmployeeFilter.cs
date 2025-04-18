using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.ControlPanel;

public record EmployeeFilter : BaseFilterModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelPhone { get; set; }
    public string CelPhone { get; set; }
    public long IdProfile { get; set; }
}

