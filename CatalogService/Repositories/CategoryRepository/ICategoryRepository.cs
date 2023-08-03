using CatalogService.Models;

namespace CatalogService.Repositories.CategoryRepository;

public interface ICategoryRepository : IDisposable
{
    Task<Category?> GetAsync(string categoryId);
    Task<IEnumerable<Category?>> GetCategoriesAsync();
    Task InsertCategoryAsync(Category? category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(string categoryId);
    Task SaveAsync();
}
