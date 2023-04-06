using Microsoft.EntityFrameworkCore;

namespace Store.Core.Models;

public sealed class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category?> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var beveragesCategory = new Category { Id = Guid.NewGuid(), Name = "Beverages" };
        modelBuilder.Entity<Category>().HasData(beveragesCategory);
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Coca-cola",
            Price = (decimal)2.0, 
            Category = beveragesCategory
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = Guid.NewGuid(),
            Name = "Pepsi",
            Price = (decimal)1.5, 
            Category = beveragesCategory
        });
    }
}
