using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.ControlPanel;

public class UserFilter : GenericFilter
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string LastPassword { get; set; }
    public bool? IsAuthenticated { get; set; }
    public long? IdProfile { get; set; }
    public bool? IsActive { get; set; }
}