using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Operation : GenericEntity
{
    public string Description { get; set; }
    public int Order { get; set; }
    public virtual IEnumerable<ProfileOperation> ProfileOperations { get; set; }
}