using System.Text.Json.Serialization;

namespace TestsWebAPI.DTO;

public record DropDownListDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
}
