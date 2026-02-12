namespace WebMinimalCarterSwaggerAPI.DTO;

public record ProductCreateDTO
{
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
}