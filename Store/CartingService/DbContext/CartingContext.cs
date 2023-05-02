using LiteDB.Async;
using Microsoft.Extensions.Options;

namespace Store.Core.DbContext;

public class CartingContext : ILiteDbContext
{
    public LiteDatabaseAsync Database { get; }
    public string CollectionName { get; }

    public CartingContext(IOptions<LiteDbOptions> options)
    {
        Database = new LiteDatabaseAsync(options.Value.DatabaseLocation);
        CollectionName = options.Value.CollectionName;
    }
}
