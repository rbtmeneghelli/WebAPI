using WebAPI.Domain.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities;

public class Profile : GenericEntity
{
    public string Description { get; set; }
    public int ProfileTypeId { get; set; }
    public List<User> Users { get; set; }
    public List<ProfileOperation> ProfileOperations { get; set; }
}
