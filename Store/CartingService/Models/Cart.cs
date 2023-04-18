namespace Store.Core.Models;

public class Cart
{
    public string Id { get; }

    public Cart()
    {
        Id = Guid.NewGuid().ToString("N");
    }
    
    public List<Item>? Items { get; set; }
}
