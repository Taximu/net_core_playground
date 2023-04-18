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

    public List<Item>? GetAllItems(string cartId)
    {
        return _cartRepository.GetCartItems(cartId);
    }

    public string Add(string cartId, Item item)
    {
        return _cartRepository.Add(cartId, item);
    }
    
    public int Remove(string cartId, int itemId)
    {
        return _cartRepository.Remove(cartId, itemId);
    }
}
