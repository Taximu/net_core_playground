using Store.Core.Models;
using Store.Core.Repositories;

namespace Store.Core.Services.CartingService;

public class CartingService : ICartingService
{
    private readonly ICartRepository _cartRepository;
    public CartingService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public List<Cart> GetCarts()
    {
        return _cartRepository.GetCarts();
    }

    public Cart GetCart(string cartId)
    {
        return _cartRepository.GetCart(cartId);
    }

    public List<Item>? GetCartItems(string cartId)
    {
        return _cartRepository.GetCartItems(cartId);
    }

    public string AddItem(string cartId, Item item)
    {
        return _cartRepository.AddItem(cartId, item);
    }
    
    public int RemoveItem(string cartId, int itemId)
    {
        return _cartRepository.RemoveItem(cartId, itemId);
    }
}
