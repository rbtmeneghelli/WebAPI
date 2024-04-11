using WebAPI.Domain.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities;

public class Role : GenericEntity
{
    public string Description { get; set; }
    public string RoleTag { get; set; }
    public EnumActions Action { get; set; }
    public long? IdOperation { get; set; }
    public virtual Operation Operation { get; set; }
}
