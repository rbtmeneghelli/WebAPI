using WebAPI_VerticalSliceArc.Domain.Entities;
using WebAPI_VerticalSliceArc.Domain.Generics.Interfaces;
using WebAPI_VerticalSliceArc.Features.Products;

namespace WebAPI_VerticalSlice.Features.Products;

public sealed class ProdutoRepository : IProdutoRepository
{
    private IGenericReadRepository<ProductEntity> _iProductReadRepository;
    private IGenericWriteRepository<ProductEntity> _iProductWriteRepository;

    public ProdutoRepository(
    IGenericReadRepository<ProductEntity> iProductReadRepository,
    IGenericWriteRepository<ProductEntity> iProductWriteRepository
    )
    {
        _iProductReadRepository = iProductReadRepository;
        _iProductWriteRepository = iProductWriteRepository;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        return await _iProductReadRepository.GetAllAsync();
    }

    public async Task<ProductEntity> GetProductByIdAsync(long productId)
    {
        return await _iProductReadRepository.GetByIdAsync(productId);
    }

    public async Task CreateProductAsync(ProductEntity product)
    {
        await _iProductWriteRepository.CreateAsync(product);
    }

    public async Task UpdateProductAsync(ProductEntity product)
    {
        await _iProductWriteRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(ProductEntity product)
    {
        await _iProductWriteRepository.DeleteAsync(product);
    }
}
