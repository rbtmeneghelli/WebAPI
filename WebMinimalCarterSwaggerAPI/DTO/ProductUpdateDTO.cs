namespace WebMinimalCarterSwaggerAPI.DTO;

public record ProductUpdateDTO
{
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedOn { get; set; }
}
