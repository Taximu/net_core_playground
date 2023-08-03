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

    public async Task<Cart?> GetCartAsync(string cartId)
    {
        return await _cartRepository.GetCartAsync(cartId);
    }

    public async Task<List<Item>> GetCartItemsAsync(string cartId)
    {
        return await _cartRepository.GetCartItemsAsync(cartId);
    }

    public async Task<string> AddItemAsync(string cartId, Item item)
    {
        return await _cartRepository.AddItemAsync(cartId, item);
    }

    public async Task<int> UpdateItemAsync(Item item)
    {
        return await _cartRepository.UpdateItemAsync(item);
    }
    
    public async Task<Cart?> RemoveItemAsync(string cartId, int itemId)
    {
        return await _cartRepository.RemoveItemAsync(cartId, itemId);
    }
}
