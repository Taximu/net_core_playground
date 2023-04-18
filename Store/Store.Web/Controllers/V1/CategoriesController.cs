using System.Net;
using CatalogService.Models;
using CatalogService.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers.V1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CategoriesController
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    /// <summary>
    /// Get all categories
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        if (result != null && !result.Any())
            return new NoContentResult();
        return new OkObjectResult(result);
    }

    /// <summary>
    /// Add new category
    /// </summary>
    /// <param name="category">Category model</param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode AddCategory(Category category)
    {
        _categoryService.Add(category);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">Category model</param>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode UpdateCategory(Category category)
    {
        _categoryService.Update(category);
        return HttpStatusCode.OK;
    }

    /// <summary>
    /// Delete category
    /// </summary>
    /// <param name="categoryId">Id of category</param>
    [HttpDelete("{categoryId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public HttpStatusCode DeleteCategory(string categoryId)
    {
        _categoryService.Delete(categoryId);
        return HttpStatusCode.OK;
    }
}