using WebAPI.Domain.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities;

public class Profile : GenericEntity
{
    public string Description { get; set; }
    public int ProfileTypeId { get; set; }
    public IEnumerable<User> Users { get; set; }
    public IEnumerable<ProfileOperation> ProfileOperations { get; set; }
}
