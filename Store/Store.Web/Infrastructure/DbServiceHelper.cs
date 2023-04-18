using CatalogService.DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Store.Web.Infrastructure;

public static class DbServiceHelper
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
