using WebMinimalAPI_Aot._2._Application.Interfaces;
using WebMinimalAPI_Aot._3._Domain.Entities;

namespace WebMinimalAPI_Aot._4._InfraStructure.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();
    public Task CreateAsync(Product product) { _products.Add(product); return Task.CompletedTask; }
    public Task<Product?> GetByIdAsync(Guid id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    public Task<IEnumerable<Product>> GetAllAsync() => Task.FromResult<IEnumerable<Product>>(_products.ToList());
    public Task UpdateAsync(Product product) => Task.CompletedTask;
    public Task DeleteAsync(Guid id) { _products.RemoveAll(p => p.Id == id); return Task.CompletedTask; }
}
