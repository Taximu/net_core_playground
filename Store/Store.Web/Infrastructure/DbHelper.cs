using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Core.Models;

namespace Store.Web.Infrastructure;

public class DbHelper
{
    public void ForceCreation()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("StoreDatabase");

        var options = new DbContextOptionsBuilder<StoreDbContext>()
            .UseSqlServer(new SqlConnection(connectionString))
            .Options;

        using var context = new StoreDbContext(options);
        context.Database.EnsureCreated();
    }
}