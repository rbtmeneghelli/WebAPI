using WebMinimalCarterSwaggerAPI.Entities;

namespace WebMinimalCarterSwaggerAPI.Builders;

public sealed class ProductUpdateBuilder
{
    private static int _productId { get; set; } = 0;
    private static string? _productName { get; set; } = string.Empty;
    private static decimal _price { get; set; } = 0;
    private static DateTime _updatedOn { get; set; }

    private ProductUpdateBuilder() { }

    public static ProductUpdateBuilder Update() => new ProductUpdateBuilder();

    public ProductUpdateBuilder SetProductId(int productId)
    {
        _productId = productId;
        return this;
    }

    public ProductUpdateBuilder SetProductName(string? productName)
    {
        _productName = productName;
        return this;
    }

    public ProductUpdateBuilder SetPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public Product Build()
    {
        return new Product
        {
            ProductId = _productId,
            ProductName = _productName,
            Price = _price,
            CreatedOn = DateTime.UtcNow,
        };
    }
}
