using Store.Web.Models;

namespace Store.Web.Services;

public interface IHateoasGenerator
{
    List<Link> CreateLinks(CartHypermedia cartHypermedia);
}