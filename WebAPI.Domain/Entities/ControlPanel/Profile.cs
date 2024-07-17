using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Profile : GenericEntity
{
    public string Description { get; set; }
    public long IdArea { get; set; }
    public virtual Area Area { get; set; }
    public virtual IEnumerable<Employee> Employees { get; set; }
    public virtual IEnumerable<ProfileOperation> ProfileOperations { get; set; }
}
