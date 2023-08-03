using Store.Core.Models;

namespace Store.Core.Services.CartingService;

public interface ICartingService
{
    /// <summary>
    /// Get cart model details
    /// </summary>
    /// <param name="cartId"></param>
    /// <returns></returns>
    Task<Cart?> GetCartAsync(string cartId);
    
    /// <summary>
    /// Get all items in cart
    /// </summary>
    Task<List<Item>> GetCartItemsAsync(string cartId);

    /// <summary>
    /// Add item to cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="item">item</param>
    Task<string> AddItemAsync(string cartId, Item item);

    /// <summary>
    /// Update item in cart
    /// </summary>
    /// <param name="item">item</param>
    Task<int> UpdateItemAsync(Item item);

    /// <summary>
    /// Remove item from cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="itemId">Id od item</param>
    Task<Cart?> RemoveItemAsync(string cartId, int itemId);
}
