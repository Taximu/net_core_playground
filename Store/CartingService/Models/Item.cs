using System.ComponentModel.DataAnnotations;

namespace Store.Core.Models;

public class Item
{
    [Required]
    public int Id { get; init; }
    
    public string ExternalId { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    public Image? Image { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    public long Quantity { get; set; }
}
