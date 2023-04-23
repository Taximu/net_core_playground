using LiteDB;
using Store.Core.DbContext;
using Store.Core.Models;

namespace Store.Core.Repositories;

public class CartRepository : ICartRepository
{
    private readonly LiteDatabase _liteDb;
    private readonly string _collectionName;

    public CartRepository(ILiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
        _collectionName = liteDbContext.CollectionName;
    }

    public List<Cart> GetCarts()
    {
        return _liteDb.GetCollection<Cart>(_collectionName).FindAll().ToList();
    }

    public Cart GetCart(string cartId)
    {
        var cart = _liteDb.GetCollection<Cart>(_collectionName).FindById(cartId);
        return cart;
    }

    public List<Item>? GetCartItems(string cartId)
    {
        var cart = _liteDb.GetCollection<Cart>(_collectionName).FindById(cartId);
        return cart.Items;
    }

    public string AddItem(string cartId, Item item)
    {
        var cart = _liteDb.GetCollection<Cart>(_collectionName).FindById(cartId) ?? new Cart();
        if (cart.Items == null)
            cart.Items = new List<Item> { item };
        else
            cart.Items.Add(item);
        _liteDb.GetCollection<Cart>(_collectionName).Insert(cart);
        return cart.Id;
    }

    public int RemoveItem(string cartId, int itemId)
    {
        var item = _liteDb.GetCollection<Item>(_collectionName).FindById(cartId);
        return 0;
    }
}
