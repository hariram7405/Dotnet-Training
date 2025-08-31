namespace ShopTrackPro.Core.DTOs.Product;

public class UpdateProductDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string Category { get; set; }
}