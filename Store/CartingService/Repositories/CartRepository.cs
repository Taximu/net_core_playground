using LiteDB;
using LiteDB.Async;
using Store.Core.DbContext;
using Store.Core.Models;

namespace Store.Core.Repositories;

public class CartRepository : ICartRepository
{
    private readonly LiteDatabaseAsync _liteDb;
    private readonly string _collectionName;

    public CartRepository(ILiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
        _collectionName = liteDbContext.CollectionName;
    }

    private async Task<IEnumerable<Cart>> GetCartsAsync()
    {
        return await _liteDb.GetCollection<Cart>(_collectionName).FindAllAsync();
    }

    public async Task<Cart?> GetCartAsync(string cartId)
    {
        ObjectId? id;
        try
        {
            id = new ObjectId(cartId);
        }
        catch (Exception ex)
        {
            return null;
        }
        return await _liteDb.GetCollection<Cart>(_collectionName).FindByIdAsync(id);
    }

    public async Task<List<Item>?> GetCartItemsAsync(string cartId)
    {
        var cart = await GetCartAsync(cartId);
        return cart?.Items;
    }

    public async Task<string> AddItemAsync(string cartId, Item item)
    {
        var cart = await GetCartAsync(cartId) ?? new Cart();

        if (cart.Items == null)
        {
            cart.Items = new List<Item> { item };
            await _liteDb.GetCollection<Cart>(_collectionName).InsertAsync(cart);
        }
        else
        {
            cart.Items.Add(item);
            await _liteDb.GetCollection<Cart>(_collectionName).UpsertAsync(cart);
        }

        return cart.Id.ToString();
    }

    public async Task<int> UpdateItemAsync(Item item)
    {
        var cartsCollection = await GetCartsAsync();
        var carts = cartsCollection.ToList();

        foreach (var cart in carts)
        {
            if (cart.Items == null) continue;
            foreach (var it in cart.Items.Where(it => it.ExternalId == item.ExternalId))
            {
                it.Name = item.Name;
                it.Image = item.Image;
                it.Price = item.Price;
                it.Quantity = item.Quantity;
            }
        }

        return await _liteDb.GetCollection<Cart>(_collectionName).UpsertAsync(carts);
    }

    public async Task<Cart?> RemoveItemAsync(string cartId, int itemId)
    {
        var cart = await GetCartAsync(cartId);
        if (cart?.Items == null) 
            return cart;
        
        var newList = new List<Item>();
        newList.AddRange(cart.Items.Where(item => item.Id != itemId));
        
        cart.Items = newList;
        await _liteDb.GetCollection<Cart>().UpsertAsync(cart);

        return cart;
    }
}
