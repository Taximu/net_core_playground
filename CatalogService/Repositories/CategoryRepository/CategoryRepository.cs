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
    
    public async Task<Category?> GetAsync(string categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }
    
    public async Task<IEnumerable<Category?>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task InsertCategoryAsync(Category? category)
    {
        _context.Categories.Add(category);
        await SaveAsync();
    }
    
    public async Task UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await SaveAsync();
    }

    public async Task DeleteCategoryAsync(string categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);
        if (category != null) 
            _context.Categories.Remove(category);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
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
