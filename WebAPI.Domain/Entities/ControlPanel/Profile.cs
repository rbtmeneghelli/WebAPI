using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Profile : BaseEntityModel
{
    public string Description { get; set; }
    public long IdArea { get; set; }
    public virtual Area Area { get; set; }
    public virtual IEnumerable<Employee> Employees { get; set; }
    public virtual IEnumerable<ProfileOperation> ProfileOperations { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
