using Store.Core.Models;

namespace Store.Core.Services.CartingService;

public class CartingService : ICartingService
{
    private readonly Cart _cart;
    public CartingService(Cart cart)
    {
        _cart = cart;
    }

    public IEnumerable<Item>? GetAll()
    {
        return _cart.Items;
    }

    public void Add(Item item)
    {
        _cart.Items?.Add(item);
    }
    
    public void Remove(Item item)
    {
        _cart.Items?.Remove(item);
    }
}
