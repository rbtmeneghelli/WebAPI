using WebMinimalAPI_Aot._3._Domain.Entities;

namespace WebMinimalAPI_Aot._2._Application.Interfaces;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}
