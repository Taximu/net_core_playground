using LiteDB;
using Store.Core.Models;

namespace Store.Core.Repositories;

public class CartRepository : ICartRepository
{
    public List<Item>? GetCartItems(string cartId)
    {
        using var db = new LiteDatabase(ConnectionString);
        var cart = db.GetCollection<Cart>(CollectionName).FindById(cartId);
        return cart.Items;
    }

    public string Add(string cartId, Item item)
    {
        using var db = new LiteDatabase(ConnectionString);
        var cart = db.GetCollection<Cart>(CollectionName).FindById(cartId) ?? new Cart();
        if (cart.Items == null)
            cart.Items = new List<Item> { item };
        else
            cart.Items.Add(item);
        return db.GetCollection<Cart>(CollectionName).Insert(cart);
    }

    public int Remove(string cartId, int itemId)
    {
        using var db = new LiteDatabase(ConnectionString);
        var item = db.GetCollection<Item>(CollectionName).FindById(cartId);
        return 0;
    }
    
    private const string CollectionName = "cartwithitems";
    private const string ConnectionString = "Carting.db";
}
