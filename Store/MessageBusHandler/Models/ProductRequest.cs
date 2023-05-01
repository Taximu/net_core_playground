using Store.Core.Models;

namespace CatalogHandler.Models;

public class ProductRequest
{
    public string Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public Image? Image { get; set; }
    
    public string CategoryId { get; set; }
    
    public decimal Price { get; set; }
    
    public uint Amount { get; set; }

    public ProductStatus Status{ get; set;}
}
