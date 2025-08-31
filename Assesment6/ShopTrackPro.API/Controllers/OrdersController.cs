using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.DTOs.Order;
using ShopTrackPro.Core.DTOs;

namespace ShopTrackPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<OrderDto>>> CreateOrder(CreateOrderDto orderDto)
    {
        var userId = GetCurrentUserId();
        var order = await orderService.CreateOrderAsync(userId, orderDto);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, new ApiResponse<OrderDto>
        {
            Message = "Order created successfully",
            Data = order
        });
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OrderDto>>>> GetUserOrders()
    {
        var userId = GetCurrentUserId();
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        
        // Admin can see all orders, customers only their own
        if (userRole == "Admin")
        {
            var allOrders = await orderService.GetUserOrdersAsync(0); // Get all orders for admin
            return Ok(new ApiResponse<IEnumerable<OrderDto>>
            {
                Message = "Orders retrieved successfully",
                Data = allOrders
            });
        }
        
        var orders = await orderService.GetUserOrdersAsync(userId);
        return Ok(new ApiResponse<IEnumerable<OrderDto>>
        {
            Message = "Orders retrieved successfully",
            Data = orders
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OrderDto>>> GetOrder(int id)
    {
        var userId = GetCurrentUserId();
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        
        // Admin can access any order, customers only their own
        if (userRole == "Admin")
        {
            var order = await orderService.GetOrderByIdAsync(id, 0); // Admin bypass user check
            return Ok(new ApiResponse<OrderDto>
            {
                Message = "Order retrieved successfully",
                Data = order
            });
        }
        
        var userOrder = await orderService.GetOrderByIdAsync(id, userId);
        return Ok(new ApiResponse<OrderDto>
        {
            Message = "Order retrieved successfully",
            Data = userOrder
        });
    }

    [HttpGet("dashboard")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<ApiResponse<object>>> GetDashboard()
    {
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        if (userRole != "Admin")
        {
            return Forbid("Access denied. Admin role required to view dashboard.");
        }
        
        var dashboard = await orderService.GetDashboardDataAsync();
        return Ok(new ApiResponse<object>
        {
            Message = "Dashboard data retrieved successfully",
            Data = dashboard
        });
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out int userId))
            throw new UnauthorizedAccessException("Invalid user ID in token");
        return userId;
    }
}