using System.Net;
using CatalogService.Models;
using CatalogService.Services.CategoryService;
using CatalogService.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CategoriesController
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    public CategoriesController(ICategoryService categoryService,  IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }
    
    /// <summary>
    /// Get all categories
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult GetAll()
    {
        var result = _categoryService.GetCategories();
        if (result != null && !result.Any())
            return new NoContentResult();
        return new OkObjectResult(result);
    }
    
    /// <summary>
    /// Get category by Id
    /// </summary>
    /// <param name="categoryId">Category's id</param>
    /// <returns></returns>
    [HttpGet("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult Get(string categoryId)
    {
        if (string.IsNullOrEmpty(categoryId))
            return new BadRequestResult();
        var category = _categoryService.Get(categoryId);
        if (string.IsNullOrEmpty(category.Id))
            return new NotFoundResult();
        return new OkObjectResult(category);
    }

    /// <summary>
    /// Add category
    /// </summary>
    /// <param name="category">Category model</param>
    [HttpPost("category", Name = nameof(AddCategory))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode AddCategory(Category? category)
    {
        _categoryService.Add(category);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">Category model</param>
    [HttpPut("category", Name = nameof(UpdateCategory))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode UpdateCategory(Category category)
    {
        _categoryService.Update(category);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Delete category
    /// </summary>
    /// <param name="categoryId">Category's id</param>
    [HttpDelete("{categoryId}", Name = nameof(DeleteCategory))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode DeleteCategory(string categoryId)
    {
        _categoryService.Delete(categoryId);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Get all products
    /// </summary>
    /// <param name="categoryId">Filter by: category id</param>
    /// <param name="skip">Skip by number</param>
    /// <param name="take">Take by number</param>
    /// <returns></returns>
    [HttpGet("{categoryId}/products", Name = nameof(Get))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult GetProducts(string categoryId, byte skip, byte take)
    {
        var result = _productService.GetAll(categoryId, skip, take);
        if (result != null && !result.Any())
            return new NoContentResult();
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Create product
    /// </summary>
    /// <param name="product">product model</param>
    /// <param name="categoryId">Category's id</param>
    [HttpPost("{categoryId}/products", Name = nameof(CreateProduct))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode CreateProduct(Product? product, string categoryId)
    {
        _productService.Add(product, categoryId);
        return HttpStatusCode.OK;
    }
    
    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="product">Product model</param>
    /// <returns></returns>
    [HttpPut("products", Name = nameof(UpdateProduct))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode UpdateProduct(Product product)
    {
        _productService.Update(product);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="productId">Product's id</param>
    /// <returns></returns>
    [HttpDelete("products/{productId}", Name = nameof(DeleteProduct))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode DeleteProduct(string productId)
    {
        _productService.Delete(productId);
        return HttpStatusCode.OK;
    }
}
