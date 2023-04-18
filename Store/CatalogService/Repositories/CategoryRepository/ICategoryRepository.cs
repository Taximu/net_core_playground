using CatalogService.Models;

namespace CatalogService.Repositories.CategoryRepository;

public interface ICategoryRepository : IDisposable
{
    IEnumerable<Category>? GetCategories();
    void InsertCategory(Category category);
    void UpdateCategory(Category category);
    void DeleteCategory(string categoryId);
    void Save();
}