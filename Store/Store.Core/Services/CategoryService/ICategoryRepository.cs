using Store.Core.Models;

namespace Store.Core.Services.CategoryService;

public interface ICategoryRepository : IDisposable
{
    IEnumerable<Category?> GetCategories();
    Category? GetCategoryById(int categoryId);
    void InsertCategory(Category category);
    void DeleteCategory(int categoryId);
    void UpdateCategory(Category category);
    void Save();
}