using Store.Web.Models;

namespace Store.Web.Services.HypermediaServices;

public interface IHateoasGenerator
{
    List<Link> CreateLinks();
}