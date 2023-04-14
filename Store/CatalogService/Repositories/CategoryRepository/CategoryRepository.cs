using CatalogService.DbContext;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repositories.CategoryRepository;

public class CategoryRepository : ICategoryRepository, IDisposable
{
    private readonly CatalogContext _context;

    public CategoryRepository(CatalogContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Category>? GetCategories()
    {
        return _context.Categories?.ToList();
    }

    public Category GetCategoryById(int categoryId)
    {
        return _context.Categories?.Find(categoryId);
    }

    public void InsertCategory(Category? category)
    {
        _context.Categories?.Add(category);
    }

    public void DeleteCategory(int categoryId)
    {
        var category = _context.Categories?.Find(categoryId);
        _context.Categories?.Remove(category);
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