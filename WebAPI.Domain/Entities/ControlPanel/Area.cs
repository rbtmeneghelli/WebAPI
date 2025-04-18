using FastPackForShare.Default;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Area : BaseEntityModel
{
    public string Description { get; set; }
    public EnumHierarchyLevel HierarchyLevel { get; set; }
    public int Order { get; set; }
    public virtual IEnumerable<Profile> Profiles { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
