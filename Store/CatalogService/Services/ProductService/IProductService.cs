using CatalogService.Models;

namespace CatalogService.Services.ProductService;

public interface IProductService
{
    /// <summary>
    /// Get all products
    /// </summary>
    IEnumerable<Product>? GetAll(string categoryId, int limit);
    
    /// <summary>
    /// Add Product
    /// </summary>
    /// <param name="product"></param>
    void Add(Product product);
    
    /// <summary>
    /// Update Product
    /// </summary>
    /// <param name="product">product</param>
    void Update(Product product);

    /// <summary>
    /// Delete product
    /// </summary>
    /// <param name="productId">id of product</param>
    void Delete(string productId);
}
