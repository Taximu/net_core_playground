using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.CartingService;

namespace Store.Web.Controllers.V2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class CartController
{
    private readonly ICartingService _cartingService;
    public CartController(ICartingService catalogService)
    {
        _cartingService = catalogService;
    }
    
    /// <summary>
    /// Get all cart items
    /// </summary>
    /// <param name="cartId">Id of cart</param>
    [HttpGet("{cartId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult GetAllCartItems(string cartId)
    {
        var items = _cartingService.GetAllItems(cartId);
        if (items != null && !items.Any())
            return new NoContentResult();
        return new OkObjectResult(JsonSerializer.Serialize(items));
    }
}
