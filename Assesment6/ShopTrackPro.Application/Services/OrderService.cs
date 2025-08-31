using AutoMapper;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.DTOs.Order;
using ShopTrackPro.Core.DTOs.Dashboard;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Exceptions;

namespace ShopTrackPro.Application.Services;

public class OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper) : IOrderService
{
    public async Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto orderDto)
    {
        // Check stock for all items
        foreach (var item in orderDto.Items)
        {
            if (!await CheckStockAsync(item.ProductId, item.Quantity))
                throw new InsufficientStockException($"Insufficient stock for product {item.ProductId}");
        }

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = "Pending",
            OrderItems = orderDto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        var created = await orderRepository.AddAsync(order);
        return mapper.Map<OrderDto>(created);
    }

    public async Task<IEnumerable<OrderDto>> GetUserOrdersAsync(int userId)
    {
        var orders = await orderRepository.GetOrdersByUserId(userId);
        return mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderByIdAsync(int orderId, int userId)
    {
        var order = await orderRepository.GetOrderWithItemsById(orderId);
        if (order == null || order.UserId != userId)
            throw new NotFoundException($"Order with ID {orderId} not found");

        return mapper.Map<OrderDto>(order);
    }

    public async Task<DashboardDto> GetDashboardDataAsync()
    {
        var orders = await orderRepository.GetOrdersWithItems();
        var products = await productRepository.GetAllAsync();

        var totalRevenue = orders.SelectMany(o => o.OrderItems)
            .Where(oi => oi.Product != null)
            .Sum(oi => oi.Quantity * oi.Product.Price);

        return new DashboardDto
        {
            TotalProducts = products.Count(),
            TotalOrders = orders.Count(),
            TotalUsers = orders.Select(o => o.UserId).Distinct().Count(),
            TotalRevenue = totalRevenue,
            TopProducts = []
        };
    }

    public async Task<bool> CheckStockAsync(int productId, int quantity)
    {
        var product = await productRepository.GetByIdAsync(productId);
        if (product == null)
            return false;
            
        // In real implementation, check actual stock levels
        // For now, assume products are in stock if quantity is reasonable
        return quantity > 0 && quantity <= 100;
    }


}