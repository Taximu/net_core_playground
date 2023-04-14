using CatalogService.Models;

namespace CatalogService.Services.ProductService;

public interface IProductService
{
    /// <summary>
    /// Get Product by id
    /// </summary>
    /// <param name="productId">id of product</param>
    Product GetById(Guid productId);

    /// <summary>
    /// Get all products
    /// </summary>
    IEnumerable<Product> GetAll();

    /// <summary>
    /// Add Product
    /// </summary>
    /// <param name="product"></param>
    void Add(Product product);
    
    /// <summary>
    /// Update Product
    /// </summary>
    /// <param name="product">product</param>
    bool Update(Product product);

    /// <summary>
    /// Delete product
    /// </summary>
    /// <param name="productId">id of product</param>
    bool Delete(Guid productId);
}
