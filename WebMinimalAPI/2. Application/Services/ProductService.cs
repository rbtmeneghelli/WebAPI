using WebMinimalAPI._2._Application.Interfaces;
using WebMinimalAPI_Aot._2._Application.Interfaces;
using WebMinimalAPI_Aot._3._Domain.Entities;

namespace WebMinimalAPI_Aot._2._Application.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(string name)
    {
        var product = new Product(name);
        await _repository.CreateAsync(product);
    }

    public Task<Product?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public async Task UpdateAsync(Guid id, string name)
    {
        var prod = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException();
        prod.UpdateName(name);
        await _repository.UpdateAsync(prod);
    }

    public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
}
