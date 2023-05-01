using CatalogService.Models;

namespace CatalogService.Services.ProductService;

public interface IProductService
{
    /// <summary>
    /// Get all products
    /// </summary>
    Task<List<Product>> GetAllAsync(string categoryId, byte skip, byte take);

    /// <summary>
    /// Add Product
    /// </summary>
    /// <param name="product"></param>
    Task AddAsync(Product? product);
    
    /// <summary>
    /// Update Product
    /// </summary>
    /// <param name="product">product</param>
    Task UpdateAsync(Product product);

    /// <summary>
    /// Delete product
    /// </summary>
    /// <param name="productId">id of product</param>
    Task DeleteAsync(string productId);
}
