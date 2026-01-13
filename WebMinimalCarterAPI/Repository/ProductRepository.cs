using Bogus;
using WebMinimalCarterAPI.Entities;
using WebMinimalCarterAPI.Repository.Interfaces;

namespace WebMinimalCarterAPI.Repository;

public sealed class ProductRepository : IProductRepository
{
    private List<Product>? products;
    private readonly ILogger<IProductRepository> _logger;

    public ProductRepository(ILogger<IProductRepository> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        GenerateSeedData();
    }

    public bool CreateProduct(Product product)
    {
        var productNameExistsAlready =
            products!.Any(p => p.ProductName == product.ProductName);

        var produtoIdExistsAlready = products!.Any(p =>
                                  p.ProductId == product.ProductId);
        if (productNameExistsAlready || produtoIdExistsAlready)
        {
            _logger.LogError("Product exists already!");
            return false;
        }
        products!.Add(product);
        return true;
    }

    public IEnumerable<Product> GetProducts()
    {
        return products!;
    }

    public Product GetProductById(int id)
    {
        return products.FirstOrDefault(a => a.ProductId == id);
    }

    public bool UpdateProduct(int id, Product product)
    {
        var p = products.FirstOrDefault(a => a.ProductId == id);
        p.ProductName = product.ProductName;
        p.CreatedOn = DateTime.Now;
        p.Price = product.Price;
        return true;
    }

    public bool DeleteProduct(int id)
    {
        var product = products!.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return false;
        }
        products!.Remove(product);
        return true;
    }

    private void GenerateSeedData()
    {
        products = new Faker<Product>()
            .RuleFor(p => p.ProductId, p => p.IndexFaker)
            .RuleFor(p => p.ProductName, p => p.Commerce.ProductName())
            .RuleFor(p => p.Price, p => Convert.ToDecimal(p.Finance.Amount()))
            .RuleFor(p => p.CreatedOn, p => p.Date.Recent())
            .Generate(50);
    }
}
