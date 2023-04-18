using Microsoft.AspNetCore.Mvc;
using Store.Core.Models;
using Store.Core.Services.CartingService;
using System.Text.Json;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CartController
{
    private readonly ICartingService _cartingService;
    public CartController(ICartingService catalogService)
    {
        _cartingService = catalogService;
    }

    /// <summary>
    /// Get full cart info: id and list of items
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <returns></returns>
    [HttpGet("{cartId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult Get(string cartId)
    {
        var items = _cartingService.GetAllItems(cartId);
        if (items != null && !items.Any())
            return new NoContentResult();
        return new OkObjectResult($"Full info about cart: '{cartId}':\n {JsonSerializer.Serialize(items)}");
    }

    /// <summary>
    /// Add product to cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="item">Product model</param>
    [HttpPost("{cartId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult AddItem(string cartId, Item item)
    {
        var result = _cartingService.Add(cartId, item);
        if (string.IsNullOrEmpty(result))
            return new NoContentResult();
        return new OkObjectResult($"Item was added to the cart");
    }

    /// <summary>
    /// Delete product from cart
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    /// <param name="itemId">Id of product</param>
    [HttpDelete("{cartId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult RemoveItem(string cartId, int itemId)
    {
        var result = _cartingService.Remove(cartId, itemId);
        if ( result > 0)
            return new OkObjectResult(result);
        return new EmptyResult();
    }
}
