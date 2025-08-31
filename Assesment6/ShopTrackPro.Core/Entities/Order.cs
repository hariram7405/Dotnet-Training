namespace ShopTrackPro.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<OrderItem> OrderItems { get; set; } = [];
    public User? User { get; set; }
}
