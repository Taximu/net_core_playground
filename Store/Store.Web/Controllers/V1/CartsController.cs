using Microsoft.AspNetCore.Mvc;
using Store.Core.Models;
using Store.Core.Services.CartingService;
using Store.Web.Models;
using Store.Web.Services.HypermediaServices;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CartsController : ControllerBase
{
    private readonly ICartingService _cartingService;
    private readonly IHateoasGenerator _hateoasGenerator;
    public CartsController(ICartingService catalogService, IHateoasGenerator hateoasGenerator)
    {
        _cartingService = catalogService;
        _hateoasGenerator = hateoasGenerator;
    }

    /// <summary>
    /// Get cart details 
    /// </summary>
    /// <param name="cartId">Cart's id</param>
    [HttpGet("{cartId}", Name = nameof(GetCart))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetCart(string cartId)
    {
        if (string.IsNullOrWhiteSpace(cartId))
            return new BadRequestResult();
        var cart = _cartingService.GetCart(cartId);
        var cartHateOas = new CartHypermedia(cart, _hateoasGenerator.CreateLinks());
        return new OkObjectResult(cartHateOas);
    }

    /// <summary>
    /// Add item to cart
    /// </summary>
    /// <param name="cartId">Cart's id</param>
    /// <param name="item">Product model</param>
    [HttpPost("{cartId}/items", Name = nameof(PostItem))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult PostItem(string cartId, Item item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = _cartingService.AddItem(cartId, item);
        if (string.IsNullOrEmpty(result))
            return new NoContentResult();
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Delete item from cart
    /// </summary>
    /// <param name="cartId">Cart's id</param>
    /// <param name="itemId">Product's id</param>
    [HttpDelete("{cartId}/items/{itemId:int}", Name = nameof(DeleteItem))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult DeleteItem(string cartId, int itemId)
    {
        var result = _cartingService.RemoveItem(cartId, itemId);
        if (result > 0)
            return new OkObjectResult(result);
        return new EmptyResult();
    }
}
