using ShopTrackPro.Core.Entities;

namespace ShopTrackPro.Core.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserId(int userId);
    Task<IEnumerable<Order>> GetOrdersWithItems();
    Task<Order?> GetOrderWithItemsById(int orderId);
}