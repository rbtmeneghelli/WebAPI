using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.ControlPanel.Users;

public record UserPaginateFilter : BaseFilterModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string LastPassword { get; set; }
    public bool? IsAuthenticated { get; set; }
    public long? IdProfile { get; set; }
}