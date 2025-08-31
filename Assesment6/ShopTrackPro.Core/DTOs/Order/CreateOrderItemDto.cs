using System.ComponentModel.DataAnnotations;

namespace ShopTrackPro.Core.DTOs.Order;

public class CreateOrderItemDto
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
    
    [Range(1, 1000)]
    public int Quantity { get; set; }
}