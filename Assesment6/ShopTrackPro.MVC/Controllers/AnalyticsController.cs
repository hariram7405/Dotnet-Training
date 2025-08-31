using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Infrastructure.Repositories;
using ShopTrackPro.MVC.Models;

namespace ShopTrackPro.MVC.Controllers;

public class AnalyticsController(AdvancedQueryRepository queryRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var dashboardData = await queryRepository.GetDashboardProjections();
        
        // Convert the anonymous object to strongly-typed view model
        var viewModel = new AnalyticsDashboardViewModel();
        
        // Use reflection to get the properties from the anonymous object
        var dashboardType = dashboardData.GetType();
        var summaryProperty = dashboardType.GetProperty("Summary");
        var topCategoriesProperty = dashboardType.GetProperty("TopCategories");
        var recentOrdersProperty = dashboardType.GetProperty("RecentOrders");
        
        if (summaryProperty?.GetValue(dashboardData) is object summary)
        {
            var summaryType = summary.GetType();
            viewModel.Summary = new DashboardSummary
            {
                TotalProducts = (int)(summaryType.GetProperty("TotalProducts")?.GetValue(summary) ?? 0),
                TotalOrders = (int)(summaryType.GetProperty("TotalOrders")?.GetValue(summary) ?? 0),
                TotalUsers = (int)(summaryType.GetProperty("TotalUsers")?.GetValue(summary) ?? 0),
                MonthlyRevenue = (decimal)(summaryType.GetProperty("MonthlyRevenue")?.GetValue(summary) ?? 0m)
            };
        }
        
        if (topCategoriesProperty?.GetValue(dashboardData) is IEnumerable<object> categories)
        {
            viewModel.TopCategories = categories.Select(c =>
            {
                var categoryType = c.GetType();
                return new CategoryInfo
                {
                    Category = (string)(categoryType.GetProperty("Category")?.GetValue(c) ?? ""),
                    ProductCount = (int)(categoryType.GetProperty("ProductCount")?.GetValue(c) ?? 0),
                    AveragePrice = (decimal)(categoryType.GetProperty("AveragePrice")?.GetValue(c) ?? 0m)
                };
            }).ToList();
        }
        
        if (recentOrdersProperty?.GetValue(dashboardData) is IEnumerable<object> orders)
        {
            viewModel.RecentOrders = orders.Select(o =>
            {
                var orderType = o.GetType();
                return new RecentOrderInfo
                {
                    Id = (int)(orderType.GetProperty("Id")?.GetValue(o) ?? 0),
                    OrderDate = (DateTime)(orderType.GetProperty("OrderDate")?.GetValue(o) ?? DateTime.MinValue),
                    Status = (string)(orderType.GetProperty("Status")?.GetValue(o) ?? ""),
                    Username = (string)(orderType.GetProperty("Username")?.GetValue(o) ?? ""),
                    ItemCount = (int)(orderType.GetProperty("ItemCount")?.GetValue(o) ?? 0)
                };
            }).ToList();
        }
        
        return View(viewModel);
    }

    public async Task<IActionResult> ProductSales()
    {
        var sales = await queryRepository.GetProductSalesAggregation();
        return View(sales);
    }

    public async Task<IActionResult> CustomerAnalysis()
    {
        var customers = await queryRepository.GetHighValueCustomers();
        var viewModel = customers.Select(c =>
        {
            var type = c.GetType();
            return new CustomerAnalysisViewModel
            {
                UserId = (int)(type.GetProperty("UserId")?.GetValue(c) ?? 0),
                Username = (string)(type.GetProperty("Username")?.GetValue(c) ?? ""),
                TotalOrders = (int)(type.GetProperty("TotalOrders")?.GetValue(c) ?? 0),
                TotalSpent = (decimal)(type.GetProperty("TotalSpent")?.GetValue(c) ?? 0m),
                AverageOrderValue = (decimal)(type.GetProperty("AverageOrderValue")?.GetValue(c) ?? 0m)
            };
        }).ToList();
        return View(viewModel);
    }

    public async Task<IActionResult> OrderDetails()
    {
        var orders = await queryRepository.GetOrderDetailsWithProducts();
        var viewModel = orders.Select(o =>
        {
            var type = o.GetType();
            return new OrderDetailsViewModel
            {
                OrderId = (int)(type.GetProperty("OrderId")?.GetValue(o) ?? 0),
                OrderDate = (DateTime)(type.GetProperty("OrderDate")?.GetValue(o) ?? DateTime.MinValue),
                CustomerName = (string)(type.GetProperty("CustomerName")?.GetValue(o) ?? ""),
                ProductName = (string)(type.GetProperty("ProductName")?.GetValue(o) ?? ""),
                Category = (string)(type.GetProperty("Category")?.GetValue(o) ?? ""),
                Quantity = (int)(type.GetProperty("Quantity")?.GetValue(o) ?? 0),
                UnitPrice = (decimal)(type.GetProperty("UnitPrice")?.GetValue(o) ?? 0m),
                LineTotal = (decimal)(type.GetProperty("LineTotal")?.GetValue(o) ?? 0m)
            };
        }).ToList();
        return View(viewModel);
    }
}