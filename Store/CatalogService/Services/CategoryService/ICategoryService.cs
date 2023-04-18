﻿using CatalogService.Models;

namespace CatalogService.Services.CategoryService;

public interface ICategoryService
{
    /// <summary>
    /// Get all categories
    /// </summary>
    IEnumerable<Category>? GetAll();

    /// <summary>
    /// Add category
    /// </summary>
    /// <param name="category"></param>
    void Add(Category category);
    
    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="category">category</param>
    void Update(Category category);

    /// <summary>
    /// Remove category
    /// </summary>
    /// <param name="categoryId">Id of category</param>
    void Delete(string categoryId);
}
