using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Store.Core.Models;

namespace Store.Web;

public class Startup
{
    private IConfigurationRoot Configuration { get; }
    
    public Startup(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    { 
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("StoreDatabase"));
        });
    }

    public void Configure(IApplicationBuilder app)
    {
    }
}