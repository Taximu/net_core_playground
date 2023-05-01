using CatalogService.Models;

namespace CatalogService.Services.CategoryService;

public interface ICategoryService
{
    /// <summary>
    /// Get category by id
    /// </summary>
    Task<Category?> GetAsync(string categoryId);
    
    /// <summary>
    /// Get all categories
    /// </summary>
    Task<IEnumerable<Category?>> GetCategoriesAsync();

    /// <summary>
    /// Add category
    /// </summary>
    /// <param name="category"></param>
    Task AddAsync(Category? category);
    
    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">category</param>
    Task UpdateAsync(Category category);

    /// <summary>
    /// Remove category
    /// </summary>
    /// <param name="categoryId">Id of category</param>
    Task DeleteAsync(string categoryId);
}
