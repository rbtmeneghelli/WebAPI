using WebMinimalCarterSwaggerAPI.Entities;

namespace WebMinimalCarterSwaggerAPI.Builders;

public sealed class ProductCreateBuilder
{
    private static int _productId { get; set; } = 0;
    private static string? _productName { get; set; } = string.Empty;
    private static decimal _price { get; set; } = 0;

    private ProductCreateBuilder() { }

    public static ProductCreateBuilder Create() => new ProductCreateBuilder();

    public ProductCreateBuilder SetProductId(int productId)
    {
        _productId = productId;
        return this;
    }

    public ProductCreateBuilder SetProductName(string? productName)
    {
        _productName = productName;
        return this;
    }

    public ProductCreateBuilder SetPrice(decimal price)
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
