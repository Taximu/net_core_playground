using LiteDB.Async;

namespace Store.Core.DbContext;

public interface ILiteDbContext
{
    LiteDatabaseAsync Database { get; }
    
    string CollectionName { get; }
}
