using WebAPI_VerticalSlice.Domain.ExtensionsMethods;
using WebAPI_VerticalSliceArc.Domain.Enum;
using WebAPI_VerticalSliceArc.Domain.Generics;

namespace WebAPI_VerticalSliceArc.Domain.Entities;

public sealed class ProductEntity : GenericEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public EnumTicketDescount TicketDescount { get; set; }

    public ProductEntity() { }

    public ProductEntity(string name, decimal price, EnumTicketDescount ticketDescount)
    {
        Id = null;
        Name = name;
        Price = price;
        TicketDescount = ticketDescount;
        CreatedAt = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        IsDeleted = false;
    }

    public void Update(string name, decimal price, EnumTicketDescount ticketDescount)
    {
        Name = name;
        Price = price;
        TicketDescount = ticketDescount;
        UpdateAt = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        IsDeleted = false;
    }

    public void Delete()
    {
        DeletedAt = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        IsDeleted = true;
    }
}
