namespace ShopTrackPro.Core.DTOs.Order;

public class CreateOrderDto
{
    public List<CreateOrderItemDto> Items { get; set; } = [];
}