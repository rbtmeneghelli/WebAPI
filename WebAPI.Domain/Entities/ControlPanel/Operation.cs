using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Operation : BaseEntityModel
{
    public string Description { get; set; }
    public int Order { get; set; }
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