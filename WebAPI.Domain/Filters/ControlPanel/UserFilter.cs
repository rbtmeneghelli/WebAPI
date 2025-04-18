using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.ControlPanel;

public sealed record UserFilter : BaseFilterModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string LastPassword { get; set; }
    public bool? IsAuthenticated { get; set; }
    public long? IdProfile { get; set; }
}