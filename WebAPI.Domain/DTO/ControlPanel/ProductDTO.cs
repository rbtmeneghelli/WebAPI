using System.ComponentModel;
using FastPackForShare.Default;

namespace WebAPI.Domain.DTO.ControlPanel;

public record ProductResponseDTO : BaseDTOModel
{
    [DisplayName("UnicCode")]
    public string UnicCode { get; init; }

    [DisplayName("Name")]
    public string Name { get; init; }


    [DisplayName("Price")]
    public decimal Price { get; init; }

    public override string ToString() => $"UnicCode: {UnicCode} - Name: {Name}";

    public ProductResponseDTO() { }

    public ProductResponseDTO(int id, string name, decimal price)
    {
        UnicCode = $"{id} - {name}";
        Name = name;
        Price = price;
    }
}
