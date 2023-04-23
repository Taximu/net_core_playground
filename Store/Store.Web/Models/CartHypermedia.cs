using Store.Core.Models;

namespace Store.Web.Models;

public class CartHypermedia
{
    public Cart cart { get; set; }

    public List<Link> link { get; set; }
}