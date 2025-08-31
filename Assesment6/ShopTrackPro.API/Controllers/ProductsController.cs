using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.DTOs.Product;
using ShopTrackPro.Core.DTOs;

namespace ShopTrackPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetProducts()
    {
        var products = await productService.GetAllProductsAsync();
        return Ok(new ApiResponse<IEnumerable<ProductDto>>
        {
            Message = "Products retrieved successfully",
            Data = products
        });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<ProductDto>>> GetProduct(int id)
    {
        var product = await productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound($"Product with ID {id} not found");
        return Ok(new ApiResponse<ProductDto>
        {
            Message = "Product retrieved successfully",
            Data = product
        });
    }

    [HttpPost]
    [Authorize(Policy = "AdminOrSeller")]
    public async Task<ActionResult<ApiResponse<ProductDto>>> CreateProduct(CreateProductDto productDto)
    {
        var product = await productService.CreateProductAsync(productDto);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, new ApiResponse<ProductDto>
        {
            Message = "Product created successfully",
            Data = product
        });
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "AdminOrSeller")]
    public async Task<ActionResult<ApiResponse>> UpdateProduct(int id, UpdateProductDto productDto)
    {
        await productService.UpdateProductAsync(id, productDto);
        return Ok(new ApiResponse
        {
            Message = "Product updated successfully"
        });
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "AdminOrSeller")]
    public async Task<ActionResult<ApiResponse>> DeleteProduct(int id)
    {
        await productService.DeleteProductAsync(id);
        return Ok(new ApiResponse
        {
            Message = "Product deleted successfully"
        });
    }

    [HttpGet("category/{category}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetProductsByCategory(string category)
    {
        var products = await productService.GetProductsByCategoryAsync(category);
        return Ok(new ApiResponse<IEnumerable<ProductDto>>
        {
            Message = "Products filtered by category successfully",
            Data = products
        });
    }

    [HttpGet("my-products")]
    [Authorize(Policy = "AdminOrSeller")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetMyProducts()
    {
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;
        
        // Admin sees all products, Seller sees only their products
        if (role == "Admin")
        {
            var allProducts = await productService.GetAllProductsAsync();
            return Ok(new ApiResponse<IEnumerable<ProductDto>>
            {
                Message = "Your products retrieved successfully",
                Data = allProducts
            });
        }
        
        // For Seller - filter products they can manage (simplified: all products)
        var products = await productService.GetAllProductsAsync();
        var limitedProducts = products.Take(10); // Sellers see limited products
        return Ok(new ApiResponse<IEnumerable<ProductDto>>
        {
            Message = "Your products retrieved successfully",
            Data = limitedProducts
        });
    }

    [HttpPost("bulk")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<List<ProductDto>>>> CreateBulkProducts([FromBody] List<CreateProductDto> products)
    {
        var createdProducts = new List<ProductDto>();
        
        foreach (var productDto in products)
        {
            var product = await productService.CreateProductAsync(productDto);
            createdProducts.Add(product);
        }
        
        return Ok(new ApiResponse<List<ProductDto>>
        {
            Message = $"{createdProducts.Count} products created successfully",
            Data = createdProducts
        });
    }
}