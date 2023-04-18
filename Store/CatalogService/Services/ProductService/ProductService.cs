using CatalogService.Models;
using CatalogService.Repositories.ProductRepository;

namespace CatalogService.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public IEnumerable<Product>? GetAll(string categoryId, int limit)
    {
        return _productRepository.GetProducts(categoryId, limit);
    }

    public void Add(Product product)
    {
        _productRepository.InsertProduct(product);
    }

    public void Update(Product product)
    {
        _productRepository.UpdateProduct(product);
    }

    public void Delete(string productId)
    {
        _productRepository.DeleteProduct(productId);
    }
}