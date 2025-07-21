using WebMinimalAPI._3._Domain.Entities;

namespace WebMinimalAPI._2._Application.Interfaces;

public interface IProductService
{
    Task CreateAsync(string name);
    Task<Product?> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, string name);
    Task DeleteAsync(Guid id);
}
