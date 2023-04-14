namespace Store.Core.Models;

public class Cart
{
    public Guid Id { get; }

    public Cart(List<Item>? items)
    {
        Items = items;
        Id = Guid.NewGuid();
    }
    
    public List<Item>? Items { get; set; }
}
