using Store.Core.Models;

namespace Store.Core.Services.CategoryService;

public interface ICategoryService
{
    /// <summary>
    /// Get category by id
    /// </summary>
    /// <param name="categoryId"></param>
    Category GetById(Guid categoryId);

    /// <summary>
    /// Get all categories
    /// </summary>
    IEnumerable<Category> GetAll();

    /// <summary>
    /// Add category
    /// </summary>
    /// <param name="category"></param>
    void Add(Category category);
    
    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">category</param>
    bool Update(Category category);

    /// <summary>
    /// Remove category
    /// </summary>
    /// <param name="categoryId">id of category</param>
    bool Delete(Guid categoryId);
}
