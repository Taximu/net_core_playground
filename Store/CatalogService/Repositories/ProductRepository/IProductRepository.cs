using CatalogService.Models;

namespace CatalogService.Repositories.ProductRepository;

public interface IProductRepository : IDisposable
{
    IEnumerable<Product>? GetProducts(string categoryId, byte skip, byte take);
    Product? GetProductById(string productId);
    void InsertProduct(Product? product);
    void DeleteProduct(string productId);
    void DeleteProductsByCategoryId(string categoryId);
    void UpdateProduct(Product product);
    void Save();
}