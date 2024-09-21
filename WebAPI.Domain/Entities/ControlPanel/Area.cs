using WebAPI.Domain.Entities.Generic;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Area : GenericEntity
{
    public string Description { get; set; }
    public EnumHierarchyLevel HierarchyLevel { get; set; }
    public int Order { get; set; }
    public virtual IEnumerable<Profile> Profiles { get; set; }
}
