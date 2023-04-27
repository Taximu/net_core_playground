using Store.Core.Models;

namespace Store.Web.Models;

public class CartHypermedia
{
    public CartHypermedia(Cart cart, List<Link> links)
    {
        Cart = cart;
        Links = links;
    }

    public Cart Cart { get; set; }

    public List<Link> Links { get; set; }
}