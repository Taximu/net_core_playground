using Store.Core.Models;

namespace Store.Core.Repositories;

public interface ICartRepository
{
    List<Cart> GetCarts();
    
    Cart GetCart(string cartId);
    
    List<Item>? GetCartItems(string cartId);

    string AddItem(string cartId, Item item);

    int RemoveItem(string cartId, int itemId);
}
