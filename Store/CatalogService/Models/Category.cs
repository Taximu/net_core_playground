using System.ComponentModel.DataAnnotations;

namespace CatalogService.Models;

public class Category
{
    [Key]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "maximum {1} characters allowed")]
    public string Name { get; set; }
    
    public string? Image { get; set; }
    
    public string? ParentCategoryId { get; set; }
}