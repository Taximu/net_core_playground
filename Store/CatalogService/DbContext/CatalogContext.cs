using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DbContext;

public sealed class CatalogContext : Microsoft.EntityFrameworkCore.DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options): base(options) { }

    public DbSet<Product?> Products { get; set; }
    public DbSet<Category?> Categories { get; set; }
    
    //TODO Change to migration script
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var beveragesCategory = new Category { Id = Guid.NewGuid().ToString("N"), Name = "Beverages" };
        modelBuilder.Entity<Category>().HasData(beveragesCategory);
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = "Coca-cola",
            Price = (decimal)2.0, 
            CategoryId = beveragesCategory.Id
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = "Pepsi",
            Price = (decimal)1.5, 
            CategoryId = beveragesCategory.Id
        });
    }
}
