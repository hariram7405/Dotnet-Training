using AutoMapper;
using ShopTrackPro.Application.Mapping;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.DTOs.Product;

namespace ShopTrackPro.Tests;

public class AutoMapperTests
{
    private readonly IMapper mapper;

    public AutoMapperTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        mapper = config.CreateMapper();
    }

    [Fact]
    public void AutoMapper_Configuration_IsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        config.AssertConfigurationIsValid();
    }

    [Fact]
    public void Product_To_ProductDto_Mapping_Works()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Description = "Test Description",
            Price = 99.99m,
            Category = "Electronics"
        };

        // Act
        var productDto = mapper.Map<ProductDto>(product);

        // Assert
        Assert.Equal(product.Id, productDto.Id);
        Assert.Equal(product.Name, productDto.Name);
        Assert.Equal(product.Description, productDto.Description);
        Assert.Equal(product.Price, productDto.Price);
        Assert.Equal(product.Category, productDto.Category);
    }

    [Fact]
    public void CreateProductDto_To_Product_Mapping_Works()
    {
        // Arrange
        var createDto = new CreateProductDto
        {
            Name = "New Product",
            Description = "New Description",
            Price = 149.99m,
            Category = "Books"
        };

        // Act
        var product = mapper.Map<Product>(createDto);

        // Assert
        Assert.Equal(createDto.Name, product.Name);
        Assert.Equal(createDto.Description, product.Description);
        Assert.Equal(createDto.Price, product.Price);
        Assert.Equal(createDto.Category, product.Category);
    }
}