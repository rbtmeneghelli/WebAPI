using WebMinimalCarterSwaggerAPI.Builders;
using WebMinimalCarterSwaggerAPI.DTO;
using WebMinimalCarterSwaggerAPI.Entities;

namespace WebMinimalCarterSwaggerAPI.Mappings;

public static class ProductMapping
{
    public static Product MapToProduct(ProductCreateDTO productCreateDTO)
    {
        ArgumentNullException.ThrowIfNull(productCreateDTO, nameof(productCreateDTO));

        return ProductBuilder
        .Create()
        .Configure(productCreateDTO)
        .Build();
    }

    public static Product MapToProduct(ProductUpdateDTO productUpdateDTO)
    {
        return ProductBuilder
        .Create()
        .Configure(productUpdateDTO)
        .Build();
    }
}
