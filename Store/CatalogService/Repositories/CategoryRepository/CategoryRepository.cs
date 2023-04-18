using CatalogService.DbContext;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repositories.CategoryRepository;

public sealed class CategoryRepository : ICategoryRepository
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

    public void InsertCategory(Category category)
    {
        _context.Categories?.Add(category);
        Save();
    }
    
    public void UpdateCategory(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        Save();
    }

    public void DeleteCategory(string categoryId)
    {
        var category = _context.Categories?.Find(categoryId);
        if (category != null) 
            _context.Categories?.Remove(category);
        Save();
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
    
    private bool _disposed;

    private void Dispose(bool disposing)
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