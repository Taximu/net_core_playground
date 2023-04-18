using CatalogService.Models;
using CatalogService.Repositories.CategoryRepository;
using CatalogService.Repositories.ProductRepository;

namespace CatalogService.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }
    
    public IEnumerable<Category>? GetAll()
    {
        return _categoryRepository.GetCategories();
    }

    public void Add(Category category)
    {
        _categoryRepository.InsertCategory(category);
    }

    public void Update(Category category)
    {
        _categoryRepository.UpdateCategory(category);
    }

    public void Delete(string categoryId)
    {
        _categoryRepository.DeleteCategory(categoryId);
        _productRepository.DeleteProductsByCategoryId(categoryId);
    }
}