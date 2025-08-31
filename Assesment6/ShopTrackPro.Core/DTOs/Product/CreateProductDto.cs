using System.ComponentModel.DataAnnotations;

namespace ShopTrackPro.Core.DTOs.Product;

public class CreateProductDto
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    
    [Required, StringLength(50)]
    public string Category { get; set; } = string.Empty;
}