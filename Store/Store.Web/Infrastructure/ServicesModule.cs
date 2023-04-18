using CatalogService.DbContext;
using CatalogService.Repositories.CategoryRepository;
using CatalogService.Repositories.ProductRepository;
using CatalogService.Services.CategoryService;
using CatalogService.Services.ProductService;
using Microsoft.EntityFrameworkCore;
using Store.Core.Repositories;
using Store.Core.Services.CartingService;
using Store.Web.Infrastructure.GlobalErrorHandler;

namespace Store.Web.Infrastructure;

public static class ServicesModule
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddDbContext<CatalogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogDB")));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.InitializeDatabase(configuration);
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartingService, CartingService>();
    }
    
    public static void ConfigureExceptionMiddleware(this WebApplication app) 
    { 
        app.UseMiddleware<ExceptionMiddleware>(); 
    }
}