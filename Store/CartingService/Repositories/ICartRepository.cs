using Store.Core.Models;

namespace Store.Core.Repositories;

public interface ICartRepository
{
    Task<Cart?> GetCartAsync(string cartId);
    
    Task<List<Item>?> GetCartItemsAsync(string cartId);

    Task<string> AddItemAsync(string cartId, Item item);

    Task<int> UpdateItemAsync(Item item);

    Task<Cart?> RemoveItemAsync(string cartId, int itemId);
}
