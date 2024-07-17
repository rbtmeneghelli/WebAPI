using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Employee : GenericEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string TelPhone { get; set; }
    public string CelPhone { get; set; }
    public long IdProfile { get; set; }
    public virtual Profile Profile { get; set; }
    public long IdUser { get; set; }
    public virtual User User { get; set; }
}
