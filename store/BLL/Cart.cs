using store.BLL.Models;

namespace store.BLL;

// Question: Should cart just be model and have separate service? Or cart should be model and the only one responsible for its internals? 
public class Cart
{
    public Guid Id { get; }
    
    public Cart()
    {
        Id = Guid.NewGuid();
    }

    public Cart(List<Item>? items)
    {
        Items = items;
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Each cart has its own list of items, which is accessible only to cart where they belong
    /// </summary>
    public List<Item>? Items { get; set; }
}
