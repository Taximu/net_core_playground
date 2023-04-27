using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Services.HypermediaServices;

public class HateoasGenerator : IHateoasGenerator
{
    private readonly IUrlHelper _urlHelper;
    public HateoasGenerator(IUrlHelper urlHelper)
    {
        _urlHelper = urlHelper;
    }
    
    public List<Link> CreateLinks()
    {
        var listOfLinks = new List<Link>
        {
            new(_urlHelper.Link(nameof(Controllers.V1.CartsController.GetCart), null),
                "self",
                "GET")
        };

        return listOfLinks;
    }
}
