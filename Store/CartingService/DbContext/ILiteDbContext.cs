using LiteDB;

namespace Store.Core.DbContext;

public interface ILiteDbContext
{
    LiteDatabase Database { get; }
    
    string CollectionName { get; }
}