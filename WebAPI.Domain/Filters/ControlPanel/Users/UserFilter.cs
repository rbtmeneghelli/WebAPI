using FastPackForShare.Enums;

namespace WebAPI.Domain.Filters.ControlPanel.Users;

public record UserFilter
{
    public bool? IsAuthenticated { get; set; } = null;
    public EnumStatus EnumStatus { get; set; } = EnumStatus.All;
}
