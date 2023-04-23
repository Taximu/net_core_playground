using Store.Core.Models;

namespace Store.Core.Services.CartingService;

public interface ICartingService
{
    /// <summary>
    /// Get all carts
    /// </summary>
    /// <returns>List of carts</returns>
    List<Cart> GetCarts();
    
    /// <summary>
    /// Get cart model details
    /// </summary>
    /// <param name="cartId"></param>
    /// <returns></returns>
    Cart GetCart(string cartId);
    
    /// <summary>
    /// Get all items in cart
    /// </summary>
    List<Item>? GetCartItems(string cartId);

    /// <summary>
    /// Add item to cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="item">item</param>
    string AddItem(string cartId, Item item);

    /// <summary>
    /// Remove item from cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="itemId">Id of item</param>
    int RemoveItem(string cartId, int itemId);
}