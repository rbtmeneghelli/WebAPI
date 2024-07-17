namespace WebAPI.Domain.Entities.ControlPanel;

public class ProfileOperation
{
    public long IdProfile { get; set; }
    public virtual Profile Profile { get; set; }
    public long IdOperation { get; set; }
    public virtual Operation Operation { get; set; }
    public string RoleTag { get; set; }
    public int Order { get; set; }
    public bool IsEnable { get; set; }
}

