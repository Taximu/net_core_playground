using CatalogService.Models;

namespace CatalogService.Repositories.ProductRepository;

public interface IProductRepository : IDisposable
{
    IEnumerable<Product>? GetProducts();
    Product GetProductById(int productId);
    void InsertProduct(Product product);
    void DeleteProduct(int productId);
    void UpdateProduct(Product product);
    void Save();
}