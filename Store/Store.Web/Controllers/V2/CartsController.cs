using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.CartingService;

namespace Store.Web.Controllers.V2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class CartsController
{
    private readonly ICartingService _cartingService;
    public CartsController(ICartingService catalogService)
    {
        _cartingService = catalogService;
    }
    
    /// <summary>
    /// Get cart items
    /// </summary>
    /// <param name="cartId">Cart's id</param>
    [HttpGet("{cartId}/items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Get(string cartId)
    {
        var items = await _cartingService.GetCartItemsAsync(cartId);
        if (!items.Any())
            return new NoContentResult();
        return new OkObjectResult(items);
    }
}
