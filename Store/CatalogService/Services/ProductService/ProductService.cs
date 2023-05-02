using CatalogHandler.Services.Publisher;
using CatalogService.Models;
using CatalogService.Repositories.ProductRepository;
using Newtonsoft.Json;

namespace CatalogService.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IPublisherWrapper _publisherWrapper;
    public ProductService(IProductRepository productRepository, IPublisherWrapper publisherWrapper)
    {
        _productRepository = productRepository;
        _publisherWrapper = publisherWrapper;
    }
    
    public async Task<List<Product>> GetAllAsync(string categoryId, byte skip, byte take)
    {
        return await _productRepository.GetProductsAsync(categoryId, skip, take);
    }

    public async Task AddAsync(Product? product)
    {
        await _productRepository.InsertProductAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await _productRepository.UpdateProductAsync(product);
        await _publisherWrapper.WriteMessage(JsonConvert.SerializeObject(product));
    }

    public async Task DeleteAsync(string productId)
    {
        await _productRepository.DeleteProductAsync(productId);
    }
}
