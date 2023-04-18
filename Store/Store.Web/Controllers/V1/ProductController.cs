using System.Net;
using CatalogService.Models;
using CatalogService.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ProductsController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    /// <summary>
    /// Get all products
    /// </summary>
    /// <param name="categoryId">Filter by: category id</param>
    /// <param name="limit">Pagination by: limit</param>
    /// <returns></returns>
    [HttpGet("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult GetAll(string categoryId, int limit)
    {
        var result = _productService.GetAll(categoryId, limit);
        if (result != null && !result.Any())
            return new NoContentResult();
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Create product
    /// </summary>
    /// <param name="product">product model</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode CreateProduct(Product product)
    {
        _productService.Add(product);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="product">product model</param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode UpdateProduct(Product product)
    {
        _productService.Update(product);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="productId">Id of product</param>
    /// <returns></returns>
    [HttpDelete("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode DeleteProduct(string productId)
    {
        _productService.Delete(productId);
        return HttpStatusCode.OK;
    }
}
