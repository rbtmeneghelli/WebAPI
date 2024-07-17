using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class UserFilter : GenericFilter
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string LastPassword { get; set; }
    public bool? IsAuthenticated { get; set; }
    public long? IdProfile { get; set; }
    public bool? IsActive { get; set; }
    public virtual Employee Employee {get; set; }
}