using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace CatalogService.Models;

public class Category
{
    [BsonId]
    public string? Id { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "maximum {1} characters allowed")]
    public string? Name { get; set; }
    
    public string? Image { get; set; }
    
    public string? ParentCategoryId { get; set; }
}