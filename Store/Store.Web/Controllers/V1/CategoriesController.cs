using CatalogService.Models;
using CatalogService.Services.CategoryService;
using CatalogService.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CategoriesController : ControllerBase
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
    public async Task<ActionResult> GetAll()
    {
        var result = await _categoryService.GetCategoriesAsync();
        if (!result.Any())
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
    public async Task<ActionResult> Get(string categoryId)
    {
        if (string.IsNullOrWhiteSpace(categoryId))
            return new BadRequestResult();
        var category = await _categoryService.GetAsync(categoryId);
        if (category == null || string.IsNullOrEmpty(category.Id))
            return new NotFoundResult();
        return new OkObjectResult(category);
    }

    /// <summary>
    /// Add category
    /// </summary>
    /// <param name="category">Category model</param>
    [HttpPost("category", Name = nameof(AddCategory))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddCategory(Category? category)
    {
        await _categoryService.AddAsync(category);
        return new OkResult();
    }

    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">Category model</param>
    [HttpPut("category", Name = nameof(UpdateCategory))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateCategory(Category category)
    {
        await _categoryService.UpdateAsync(category);
        return new OkResult();
    }

    /// <summary>
    /// Delete category
    /// </summary>
    /// <param name="categoryId">Category's id</param>
    [HttpDelete("{categoryId}", Name = nameof(DeleteCategory))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteCategory(string categoryId)
    {
        await _categoryService.DeleteAsync(categoryId);
        return new OkResult();
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
    public async Task<ActionResult> GetProducts(string categoryId, byte skip = 0, byte take = 10)
    {
        var result = await _productService.GetAllAsync(categoryId, skip, take);
        if (!result.Any())
            return new NoContentResult();
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Create product
    /// </summary>
    /// <param name="product">product model</param>
    [HttpPost("products", Name = nameof(CreateProduct))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        await _productService.AddAsync(product);
        return new OkObjectResult(true);
    }
    
    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="product">Product model</param>
    /// <returns></returns>
    [HttpPut("products", Name = nameof(UpdateProduct))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> UpdateProduct(Product product)
    {
        await _productService.UpdateAsync(product);
        return new OkResult();
    }

    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="productId">Product's id</param>
    /// <returns></returns>
    [HttpDelete("products/{productId}", Name = nameof(DeleteProduct))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteProduct(string productId)
    {
        await _productService.DeleteAsync(productId);
        return new OkResult();
    }
}
