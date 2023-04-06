using System.ComponentModel.DataAnnotations;

namespace Store.Core.Models;

public class Item
{
    [Required]
    public int Id { get; init; }
    
    [Required]
    public string? Name { get; set; }
    
    public string? Image { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    public long Quantity { get; set; }
}
