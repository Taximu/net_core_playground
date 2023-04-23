using CatalogService.Models;

namespace CatalogService.Repositories.CategoryRepository;

public interface ICategoryRepository : IDisposable
{
    Category? Get(string categoryId);
    IEnumerable<Category?>? GetCategories();
    void InsertCategory(Category? category);
    void UpdateCategory(Category category);
    void DeleteCategory(string categoryId);
    void Save();
}