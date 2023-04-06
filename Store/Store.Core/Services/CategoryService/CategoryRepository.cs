using Microsoft.EntityFrameworkCore;
using Store.Core.Models;

namespace Store.Core.Services.CategoryService;

public class CategoryRepository : ICategoryRepository, IDisposable
{
    private readonly StoreDbContext _context;

    public CategoryRepository(StoreDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Category?> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category? GetCategoryById(int categoryId)
    {
        return _context.Categories.Find(categoryId);
    }

    public void InsertCategory(Category category)
    {
        _context.Categories.Add(category);
    }

    public void DeleteCategory(int categoryId)
    {
        var category = _context.Categories.Find(categoryId);
        _context.Categories.Remove(category);
    }

    public void UpdateCategory(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}