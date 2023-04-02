using store.BLL.Models;

namespace store.BLL.Services;

public class CartingService : ICartingService
{
    private readonly Cart _cart;
    public CartingService(Cart cart)
    {
        _cart = cart;
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
