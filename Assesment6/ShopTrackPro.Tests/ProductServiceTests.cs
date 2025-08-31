using Moq;
using AutoMapper;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.DTOs.Product;
using ShopTrackPro.Application.Mapping;

namespace ShopTrackPro.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> mockRepository;
    private readonly IMapper mapper;
    private readonly ProductService service;

    public ProductServiceTests()
    {
        mockRepository = new Mock<IProductRepository>();
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
        service = new ProductService(mockRepository.Object, mapper);
    }

    [Fact]
    public async Task GetProductByIdAsync_ExistingProduct_ReturnsProductDto()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test Product", Price = 99.99m };
        mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(product);

        // Act
        var result = await service.GetProductByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Product", result.Name);
        Assert.Equal(99.99m, result.Price);
    }

    [Fact]
    public async Task CreateProductAsync_ValidProduct_ReturnsProductDto()
    {
        // Arrange
        var createDto = new CreateProductDto { Name = "New Product", Price = 50.00m };
        var product = new Product { Id = 1, Name = "New Product", Price = 50.00m };
        mockRepository.Setup(r => r.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

        // Act
        var result = await service.CreateProductAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("New Product", result.Name);
        Assert.Equal(50.00m, result.Price);
    }
}