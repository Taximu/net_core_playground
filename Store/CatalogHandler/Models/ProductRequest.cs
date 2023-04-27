namespace CatalogHandler.Models;

public class ProductRequest
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public ProductStatus Status{ get; set;}
}
