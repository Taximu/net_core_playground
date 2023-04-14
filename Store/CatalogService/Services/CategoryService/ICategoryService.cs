namespace CatalogService.Services.CategoryService;

public interface ICategoryService
{
    /// <summary>
    /// Get category by id
    /// </summary>
    /// <param name="categoryId"></param>
    Models.Category GetById(Guid categoryId);

    /// <summary>
    /// Get all categories
    /// </summary>
    IEnumerable<Models.Category> GetAll();

    /// <summary>
    /// Add category
    /// </summary>
    /// <param name="category"></param>
    void Add(Models.Category category);
    
    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">category</param>
    bool Update(Models.Category category);

    /// <summary>
    /// Remove category
    /// </summary>
    /// <param name="categoryId">id of category</param>
    bool Delete(Guid categoryId);
}
