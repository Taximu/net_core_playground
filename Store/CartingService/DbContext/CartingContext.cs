using LiteDB;
using Microsoft.Extensions.Options;

namespace Store.Core.DbContext;

public class CartingContext : ILiteDbContext
{
    public LiteDatabase Database { get; }
    public string CollectionName { get; }

    public CartingContext(IOptions<LiteDbOptions> options)
    {
        Database = new LiteDatabase(options.Value.DatabaseLocation);
        CollectionName = options.Value.CollectionName;
    }
}