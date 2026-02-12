using WebMinimalCarterSwaggerAPI.Builders;
using WebMinimalCarterSwaggerAPI.DTO;
using WebMinimalCarterSwaggerAPI.Entities;

namespace WebMinimalCarterSwaggerAPI.Mappings;

public static class ProductMapping
{
    public static Product TransformToEntity(ProductCreateDTO productCreateDTO)
    {
        ArgumentNullException.ThrowIfNull(productCreateDTO, nameof(productCreateDTO));

        return ProductCreateBuilder
        .Create()
        .SetProductName(productCreateDTO.ProductName)
        .SetPrice(productCreateDTO.Price)
        .Build();
    }

    public static Product TransformToEntity(ProductUpdateDTO productUpdateDTO)
    {
        ArgumentNullException.ThrowIfNull(productUpdateDTO, nameof(productUpdateDTO));

        return ProductCreateBuilder
        .Create()
        .SetProductName(productUpdateDTO.ProductName)
        .SetPrice(productUpdateDTO.Price)
        .Build();
    }
}
