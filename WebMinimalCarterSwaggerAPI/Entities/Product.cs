namespace WebMinimalCarterSwaggerAPI.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedOn { get; set; }

    public bool IsValid()
    {
        return
        ProductId != 0 &&
        !string.IsNullOrWhiteSpace(ProductName) &&
        Price >= 0;
    }
}
