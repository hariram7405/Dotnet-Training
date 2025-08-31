using AutoMapper;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.DTOs.Product;
using ShopTrackPro.Core.DTOs.Dashboard;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Exceptions;

namespace ShopTrackPro.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await productRepository.GetAllAsync().ConfigureAwait(false);
        return mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (product == null)
            throw new NotFoundException($"Product with ID {id} not found");

        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto)
    {
        var product = mapper.Map<Product>(productDto);
        var created = await productRepository.AddAsync(product).ConfigureAwait(false);
        return mapper.Map<ProductDto>(created);
    }

    public async Task UpdateProductAsync(int id, UpdateProductDto productDto)
    {
        var product = await productRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (product == null)
            throw new NotFoundException($"Product with ID {id} not found");

        mapper.Map(productDto, product);
        await productRepository.UpdateAsync(product).ConfigureAwait(false);
    }

    public async Task DeleteProductAsync(int id)
    {
        if (!await productRepository.ExistsAsync(id).ConfigureAwait(false))
            throw new NotFoundException($"Product with ID {id} not found");

        await productRepository.DeleteAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category)
    {
        var products = await productRepository.GetByCategory(category).ConfigureAwait(false);
        return mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductSalesDto>> GetTopSellingProductsAsync()
    {
        // Mock implementation - would need OrderRepository for real data
        var products = await productRepository.GetAllAsync().ConfigureAwait(false);
        return products.Take(5).Select(p => new ProductSalesDto
        {
            ProductId = p.Id,
            ProductName = p.Name,
            TotalSold = 10, // Mock data
            TotalRevenue = p.Price * 10
        });
    }
}