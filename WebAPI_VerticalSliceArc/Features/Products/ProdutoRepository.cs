using WebAPI_VerticalSlice.InfraStructure.Context;
using WebAPI_VerticalSliceArc.Domain.Entities;
using WebAPI_VerticalSliceArc.Domain.Generics;

namespace WebAPI_VerticalSlice.Features.Products;

public sealed class ProdutoRepository : GenericRepository<ProductEntity>
{

    public ProdutoRepository(WebAPIDbContext dbContext): base(dbContext)
    {    
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        return await GetAllAsync();
    }

    public async Task<ProductEntity> GetProductByIdAsync(long productId)
    {
        return await GetByIdAsync(productId);
    }

    public async Task CreateProductAsync(ProductEntity product)
    {
        await CreateAsync(product);
    }

    public async Task UpdateProductAsync(ProductEntity product)
    {
        await UpdateAsync(product);
    }

    public async Task DeleteProductAsync(ProductEntity product)
    {
        await DeleteAsync(product);
    }
}
