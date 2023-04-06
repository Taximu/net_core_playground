using System.ComponentModel.DataAnnotations;

namespace Store.Core.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "maximum {1} characters allowed")]
    public string Name { get; set; }
    
    public string? Image { get; set; }
    
    public string? ParentCategory { get; set; }
}