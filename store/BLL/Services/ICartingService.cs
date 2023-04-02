using store.BLL.Models;

namespace store.BLL.Services;

public interface ICartingService
{
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