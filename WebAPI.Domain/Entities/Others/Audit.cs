using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Others;

public class Audit : BaseEntityModel
{
    public string TableName { get; set; }
    public string ActionName { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
