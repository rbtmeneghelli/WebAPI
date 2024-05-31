using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities;

public class Operation : GenericEntity
{
    public string Description { get; set; }
    public virtual IEnumerable<ProfileOperation> ProfileOperations { get; set; }
    public virtual IEnumerable<Role> Roles { get; set; }
}
