using CatalogService.DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Store.Web;

public static class ServiceExtensions
{
    public static void InitializeDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CatalogDB");

        var options = new DbContextOptionsBuilder<CatalogContext>()
            .UseSqlServer(new SqlConnection(connectionString))
            .Options;

        using var context = new CatalogContext(options);
        context.Database.EnsureCreated();
    }
}
