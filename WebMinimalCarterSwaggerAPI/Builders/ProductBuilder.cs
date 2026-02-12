using WebMinimalCarterSwaggerAPI.DTO;
using WebMinimalCarterSwaggerAPI.Entities;

namespace WebMinimalCarterSwaggerAPI.Builders;

public sealed class ProductBuilder
{
    private static int? _id { get; set; } = null;
    private static string? _name { get; set; } = string.Empty;
    private static decimal _price { get; set; } = 0;
    private static DateTime? _createdOn { get; set; } = null;
    private static DateTime? _updatedOn { get; set; } = null;

    private ProductBuilder() { }

    public static ProductBuilder Create() => new ProductBuilder();

    public ProductBuilder ConfigureId(int? id)
    {
        _id = id;
        return this;
    }

    public ProductBuilder ConfigureName(string name)
    {
        _name = name;
        return this;
    }

    public ProductBuilder ConfigurePrice(decimal price)
    {
        _price = price;
        return this;
    }

    public ProductBuilder ConfigureCreatedOn(DateTime? createdOn)
    {
        _createdOn = createdOn;
        return this;
    }

    public ProductBuilder ConfigureUpdatedOn(DateTime? updatedOn)
    {
        _updatedOn = updatedOn;
        return this;
    }

    public ProductBuilder Configure(ProductCreateDTO productCreateDTO)
    {
        ArgumentNullException.ThrowIfNull(productCreateDTO, nameof(productCreateDTO));
        _id = productCreateDTO.ProductId;
        _name = productCreateDTO.ProductName;
        _price = productCreateDTO.Price;
        _createdOn = DateTime.UtcNow;
        return this;
    }

    public ProductBuilder Configure(ProductUpdateDTO productUpdateDTO)
    {
        ArgumentNullException.ThrowIfNull(productUpdateDTO, nameof(productUpdateDTO));
        _id = productUpdateDTO.ProductId;
        _name = productUpdateDTO.ProductName;
        _price = productUpdateDTO.Price;
        _updatedOn = DateTime.UtcNow;
        return this;
    }

    public Product Build()
    {
        return new Product
        {
            ProductId = _id,
            ProductName = _name,
            Price = _price,
            CreatedOn = _createdOn,
            UpdatedOn = _updatedOn,
        };
    }
}
