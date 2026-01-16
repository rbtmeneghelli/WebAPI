using WebMinimalCarterSwaggerAPI.Entities;

namespace WebMinimalCarterSwaggerAPI.Repository.Interfaces;

public interface IProductRepository
{
    bool CreateProduct(Product product);
    IEnumerable<Product> GetProducts();
    Product GetProductById(int id);
    bool UpdateProduct(int id, Product product);
    bool DeleteProduct(int id);
}
