using System.Diagnostics;
using CatalogHandler.Services;
using CatalogHandler.Services.Publisher;
using CatalogHandler.Services.Subscriber;
using CatalogService.DbContext;
using CatalogService.Repositories.CategoryRepository;
using CatalogService.Repositories.ProductRepository;
using CatalogService.Services.CategoryService;
using CatalogService.Services.ProductService;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Store.Core.DbContext;
using Store.Core.Repositories;
using Store.Core.Services.CartingService;
using Store.Web.Infrastructure;
using Store.Web.Infrastructure.GlobalErrorHandler;
using Store.Web.Services.HypermediaServices;

namespace Store.Web.Services;

public static class ServicesModule
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddScoped<IUrlHelper>(x => {
            var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
            var factory = x.GetRequiredService<IUrlHelperFactory>();
            Debug.Assert(actionContext != null, nameof(actionContext) + " != null");
            return factory.GetUrlHelper(actionContext);
        });
        
        var producerConfig = new ProducerConfig();
        var consumerConfig = new ConsumerConfig();
        configuration.Bind("producer", producerConfig);
        configuration.Bind("consumer", consumerConfig);
        services.AddSingleton(producerConfig);
        services.AddSingleton(consumerConfig);
        services.AddSingleton<IPublisherWrapper, PublisherWrapper>();
        services.AddSingleton<ISubscriberWrapper, SubscriberWrapper>();
        
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
        //services.AddSingleton<IHostedService, ProcessProductsService>();
    }
    
    public static void ConfigureExceptionMiddleware(this WebApplication app)
    { 
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
