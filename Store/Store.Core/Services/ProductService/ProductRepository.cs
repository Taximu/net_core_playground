using Microsoft.EntityFrameworkCore;
using Store.Core.Models;

namespace Store.Core.Services.ProductService;

public class ProductRepository : IProductRepository, IDisposable
{
    private readonly StoreDbContext _context;

    public ProductRepository(StoreDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Product?> GetProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProductById(int productId)
    {
        return _context.Products.Find(productId);
    }

    public void InsertProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void DeleteProduct(int productId)
    {
        var product = _context.Products.Find(productId);
        _context.Products.Remove(product);
    }

    public void UpdateProduct(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
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