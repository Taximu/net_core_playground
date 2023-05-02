using Microsoft.AspNetCore.Mvc;
using Store.Core.Models;
using Store.Core.Services.CartingService;
using Store.Web.Models;
using Store.Web.Services.HypermediaServices;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/{cartId}")]
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
    [HttpGet(Name = nameof(GetCart))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetCart(string cartId)
    {
        if (string.IsNullOrWhiteSpace(cartId))
            return new BadRequestResult();
        var cart = await _cartingService.GetCartAsync(cartId);
        var cartHateOas = new CartHypermedia(cart, _hateoasGenerator.CreateLinks());
        return new OkObjectResult(cartHateOas);
    }

    /// <summary>
    /// Add item to cart
    /// </summary>
    /// <param name="cartId">Cart's id</param>
    /// <param name="item">Product model</param>
    [HttpPost("items", Name = nameof(PostItem))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> PostItem(string cartId, Item item)
    {
        var result = await _cartingService.AddItemAsync(cartId, item);
        return new OkObjectResult($"cartId: {result}");
    }

    /// <summary>
    /// Delete item from cart
    /// </summary>
    /// <param name="cartId">Cart's id</param>
    /// <param name="itemId">Id of item</param>
    [HttpDelete("items/{itemId:int}", Name = nameof(DeleteItem))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteItem(string cartId, int itemId)
    {
        var cart = await _cartingService.RemoveItemAsync(cartId, itemId);
        return new OkObjectResult(cart);
    }
}
