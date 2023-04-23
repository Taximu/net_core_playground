using CatalogService.DbContext;
using CatalogService.Repositories.CategoryRepository;
using CatalogService.Repositories.ProductRepository;
using CatalogService.Services.CategoryService;
using CatalogService.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Store.Core.DbContext;
using Store.Core.Repositories;
using Store.Core.Services.CartingService;
using Store.Web.Infrastructure.GlobalErrorHandler;
using Store.Web.Services;

namespace Store.Web.Infrastructure;

public static class ServicesModule
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddScoped<IUrlHelper>(x => {
            var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            var factory = x.GetRequiredService<IUrlHelperFactory>();
            return factory.GetUrlHelper(actionContext);
        });
        
        services.AddScoped<IHateoasGenerator, HateoasGenerator>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddDbContext<CatalogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogDB")));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.InitializeDatabase(configuration);
        services.AddSingleton<ILiteDbContext, CartingContext>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartingService, CartingService>();
        services.AddRouting(options => options.LowercaseUrls = true);
    }
    
    public static void ConfigureExceptionMiddleware(this WebApplication app) 
    { 
        app.UseMiddleware<ExceptionMiddleware>(); 
    }
}