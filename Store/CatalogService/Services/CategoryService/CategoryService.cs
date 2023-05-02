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

    public async Task<Category?> GetAsync(string categoryId)
    {
        return await _categoryRepository.GetAsync(categoryId);
    }

    public async Task<IEnumerable<Category?>> GetCategoriesAsync()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task AddAsync(Category? category)
    {
        await _categoryRepository.InsertCategoryAsync(category);
    }

    public async Task UpdateAsync(Category category)
    {
        await _categoryRepository.UpdateCategoryAsync(category);
    }

    public async Task DeleteAsync(string categoryId)
    {
        await _categoryRepository.DeleteCategoryAsync(categoryId);
        await _productRepository.DeleteProductsByCategoryIdAsync(categoryId);
    }
}
