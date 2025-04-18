using FastPackForShare.Default;

namespace WebAPI.Domain.Entities.ControlPanel;

public class Product : BaseEntityModel
{
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
