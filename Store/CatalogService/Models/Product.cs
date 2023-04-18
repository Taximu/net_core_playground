using System.ComponentModel.DataAnnotations;

namespace CatalogService.Models;

public class Product
{
    [Key]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(50, ErrorMessage = "maximum {1} characters allowed")]
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    [Required]
    public string CategoryId { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public uint Amount { get; set; }
}
