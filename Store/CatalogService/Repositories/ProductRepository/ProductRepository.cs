using CatalogService.DbContext;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repositories.ProductRepository;

public sealed class ProductRepository : IProductRepository
{
    private readonly CatalogContext _context;

    public ProductRepository(CatalogContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product>> GetProductsAsync(string categoryId, byte skip, byte take)
    {
        return await _context.Products?
            .Where(product => product.CategoryId == categoryId)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(string productId)
    {
        return await _context.Products.FindAsync(productId);
    }

    public async Task InsertProductAsync(Product? product)
    {
        await _context.Products.AddAsync(product);
        await SaveAsync();
    }
    
    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await SaveAsync();
    }

    public async Task DeleteProductAsync(string productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null) _context.Products.Remove(product);
        await SaveAsync();
    }

    public async Task DeleteProductsByCategoryIdAsync(string categoryId)
    {
        var itemsToDelete = _context.Products.Where(x => x.CategoryId == categoryId);
        if (itemsToDelete.Any())
        {
            _context.RemoveRange(itemsToDelete);
            await SaveAsync();
        }
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
