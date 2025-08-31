using ShopTrackPro.Core.DTOs.Order;
using ShopTrackPro.Core.DTOs.Dashboard;

namespace ShopTrackPro.Core.Interfaces;

public interface IOrderService
{
    Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto orderDto);
    Task<IEnumerable<OrderDto>> GetUserOrdersAsync(int userId);
    Task<OrderDto> GetOrderByIdAsync(int orderId, int userId);
    Task<DashboardDto> GetDashboardDataAsync();
    Task<bool> CheckStockAsync(int productId, int quantity);
}