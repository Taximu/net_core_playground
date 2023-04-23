using CatalogService.Models;

namespace CatalogService.Services.ProductService;

public interface IProductService
{
    /// <summary>
    /// Get all products
    /// </summary>
    IEnumerable<Product>? GetAll(string categoryId, byte skip, byte take);

    /// <summary>
    /// Add Product
    /// </summary>
    /// <param name="product"></param>
    /// <param name="categoryId"></param>
    void Add(Product? product, string categoryId);
    
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
