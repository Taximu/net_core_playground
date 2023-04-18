using Store.Core.Models;

namespace Store.Core.Services.CartingService;

public interface ICartingService
{
    /// <summary>
    /// Get all items in cart
    /// </summary>
    List<Item>? GetAllItems(string cartId);

    /// <summary>
    /// Add item to cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="item">item</param>
    string Add(string cartId, Item item);

    /// <summary>
    /// Remove item from cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="itemId">Id of item</param>
    int Remove(string cartId, int itemId);
}