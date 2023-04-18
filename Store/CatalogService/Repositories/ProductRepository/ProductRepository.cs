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
    
    public IEnumerable<Product>? GetProducts(string categoryId, int limit)
    {
        return _context.Products?
            .Where(b => b.CategoryId == categoryId)
            .Skip(limit)
            .Take(limit)
            .ToList();
    }

    public Product GetProductById(string productId)
    {
        return _context.Products?.Find(productId);
    }

    public void InsertProduct(Product product)
    {
        _context.Products?.Add(product);
        Save();
    }
    
    public void UpdateProduct(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        Save();
    }

    public void DeleteProduct(string productId)
    {
        var product = _context.Products?.Find(productId);
        if (product != null) _context.Products?.Remove(product);
        Save();
    }

    public void DeleteProductsByCategoryId(string categoryId)
    {
        if (_context.Products == null) return;
        var itemsToDelete = _context.Products.Where(x => x.CategoryId == categoryId);
        _context.RemoveRange(itemsToDelete);
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