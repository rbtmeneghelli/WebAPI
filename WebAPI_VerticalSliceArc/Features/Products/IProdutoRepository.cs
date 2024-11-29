using WebAPI_VerticalSliceArc.Domain.Entities;

namespace WebAPI_VerticalSliceArc.Features.Products;

public interface IProdutoRepository
{
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<ProductEntity> GetProductByIdAsync(long productId);
    Task CreateProductAsync(ProductEntity product);
    Task UpdateProductAsync(ProductEntity product);
    Task DeleteProductAsync(ProductEntity product);
}
