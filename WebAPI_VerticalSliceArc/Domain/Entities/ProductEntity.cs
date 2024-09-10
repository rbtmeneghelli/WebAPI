using WebAPI_VerticalSlice.Domain.ExtensionsMethods;
using WebAPI_VerticalSliceArc.Domain.Generics;

namespace WebAPI_VerticalSliceArc.Domain.Entities;

public sealed class ProductEntity : GenericEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;

    public ProductEntity(string name, decimal price)
    {
        Id = null;
        Name = name;
        Price = price;
        CreatedAt = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        IsDeleted = false;
    }

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;
        UpdateAt = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        IsDeleted = false;
    }

    public void Delete()
    {
        DeletedAt = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        IsDeleted = true;
    }
}
