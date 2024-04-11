using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities;

public class Operation : GenericEntity
{
    public string Description { get; set; }
    public virtual List<ProfileOperation> ProfileOperations { get; set; }
    public virtual List<Role> Roles { get; set; }
}
