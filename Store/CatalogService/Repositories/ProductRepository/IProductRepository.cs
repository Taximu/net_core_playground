using CatalogService.Models;

namespace CatalogService.Repositories.ProductRepository;

public interface IProductRepository : IDisposable
{
    Task<List<Product>> GetProductsAsync(string categoryId, byte skip, byte take);
    Task<Product?> GetProductByIdAsync(string productId);
    Task InsertProductAsync(Product? product);
    Task DeleteProductAsync(string productId);
    Task DeleteProductsByCategoryIdAsync(string categoryId);
    Task UpdateProductAsync(Product product);
    Task SaveAsync();
}
