using CatalogService.Models;

namespace CatalogService.Repositories.CategoryRepository;

public interface ICategoryRepository : IDisposable
{
    IEnumerable<Category>? GetCategories();
    Category GetCategoryById(int categoryId);
    void InsertCategory(Category category);
    void DeleteCategory(int categoryId);
    void UpdateCategory(Category category);
    void Save();
}