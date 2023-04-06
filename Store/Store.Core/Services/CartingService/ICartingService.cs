using Store.Core.Models;

namespace Store.Core.Services.CartingService;

public interface ICartingService
{
    /// <summary>
    /// Get all items in cart
    /// </summary>
    IEnumerable<Item>? GetAll();
    
    /// <summary>
    /// Add item to cart
    /// </summary>
    /// <param name="item">item</param>
    void Add(Item item);

    /// <summary>
    /// Remove item from cart
    /// </summary>
    /// <param name="item">item</param>
    void Remove(Item item);
}