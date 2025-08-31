using Moq;
using AutoMapper;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.DTOs.Order;
using ShopTrackPro.Core.Exceptions;

namespace ShopTrackPro.Tests;

public class OrderServiceTests
{
    private readonly Mock<IOrderRepository> mockOrderRepository;
    private readonly Mock<IProductRepository> mockProductRepository;
    private readonly Mock<IMapper> mockMapper;
    private readonly OrderService service;

    public OrderServiceTests()
    {
        mockOrderRepository = new Mock<IOrderRepository>();
        mockProductRepository = new Mock<IProductRepository>();
        mockMapper = new Mock<IMapper>();
        service = new OrderService(mockOrderRepository.Object, mockProductRepository.Object, mockMapper.Object);
    }

    [Fact]
    public async Task CreateOrderAsync_ValidOrder_ReturnsOrderDto()
    {
        // Arrange
        var createDto = new CreateOrderDto
        {
            Items = new List<CreateOrderItemDto> { new() { ProductId = 1, Quantity = 2 } }
        };
        var product = new Product { Id = 1, Name = "Test Product", Price = 100 };
        var order = new Order { Id = 1, UserId = 1, Status = "Pending" };
        var orderDto = new OrderDto { Id = 1, UserId = 1, Status = "Pending" };

        mockProductRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);
        mockOrderRepository.Setup(r => r.AddAsync(It.IsAny<Order>())).ReturnsAsync(order);
        mockMapper.Setup(m => m.Map<OrderDto>(order)).Returns(orderDto);

        // Act
        var result = await service.CreateOrderAsync(1, createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Pending", result.Status);
    }

    [Fact]
    public async Task CreateOrderAsync_InsufficientStock_ThrowsException()
    {
        // Arrange
        var createDto = new CreateOrderDto
        {
            Items = new List<CreateOrderItemDto> { new() { ProductId = 999, Quantity = 1 } }
        };

        mockProductRepository.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((Product?)null);

        // Act & Assert
        await Assert.ThrowsAsync<InsufficientStockException>(() => service.CreateOrderAsync(1, createDto));
    }

    [Fact]
    public async Task GetUserOrdersAsync_ValidUserId_ReturnsOrders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new() { Id = 1, UserId = 1, Status = "Completed" }
        };
        var orderDtos = new List<OrderDto>
        {
            new() { Id = 1, UserId = 1, Status = "Completed" }
        };

        mockOrderRepository.Setup(r => r.GetOrdersByUserId(1)).ReturnsAsync(orders);
        mockMapper.Setup(m => m.Map<IEnumerable<OrderDto>>(orders)).Returns(orderDtos);

        // Act
        var result = await service.GetUserOrdersAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }
}