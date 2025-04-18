using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailTemplate : BaseEntityModel
{
    public string Description { get; set; }
    public virtual List<EmailDisplay> EmailDisplays { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
