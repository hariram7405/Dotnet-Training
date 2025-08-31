using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Core.Interfaces;

namespace ShopTrackPro.MVC.Controllers;

public class ProductController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAllProductsAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await productService.GetProductByIdAsync(id);
        return View(product);
    }

    public async Task<IActionResult> Category(string category)
    {
        var products = await productService.GetProductsByCategoryAsync(category);
        ViewBag.Category = category;
        return View("Index", products);
    }
}