namespace CatalogHandler.Models;

public class Item
{
    public string Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string CategoryId { get; set; }
    
    public decimal Price { get; set; }
    
    public uint Amount { get; set; }
}