using LiteDB;
using store.BLL.Models;

namespace store.DAL;
public class Repository : IRepository
{
    private const string CollectionName = "items";
    private const string ConnectionString = "TestData.db";

    public IEnumerable<Item> GetAll(int limit = 10)
    {
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<Item>(CollectionName);
        return col.Query().Limit(limit).ToList();
    }
    
    public void Create(Item item)
    {
        using var db = new LiteDatabase(ConnectionString);
        db.GetCollection<Item>(CollectionName).Insert(item);
    }

    public void Update(Item item)
    {
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<Item>(CollectionName);
        var itemForUpdate = col.Query().Where(x => x.Id == item.Id).SingleOrDefault();

        itemForUpdate.Name = item.Name;
        col.Update(itemForUpdate);
    }

    public void Delete(int itemId)
    {
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<Item>(CollectionName);
        col.Delete(itemId);
    }
}
