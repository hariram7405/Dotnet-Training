using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Infrastructure.Data;
using ShopTrackPro.Core.DTOs.Dashboard;

namespace ShopTrackPro.Infrastructure.Repositories;

public class AdvancedQueryRepository(ShopTrackProContext context)
{
    // 1. Filter products by category, sort by price
    public async Task<IEnumerable<ShopTrackPro.Core.Entities.Product>> GetProductsByCategoryAndPrice(string category, bool ascending = true)
    {
        var query = context.Products.Where(p => p.Category == category);
        
        var efProducts = ascending 
            ? await query.OrderBy(p => p.Price).ToListAsync()
            : await query.OrderByDescending(p => p.Price).ToListAsync();
            
        return efProducts;
    }

    // 2. Join orders with users
    public async Task<IEnumerable<object>> GetOrdersWithUserDetails()
    {
        return await context.Orders
            .Join(context.Users,
                order => order.UserId,
                user => user.Id,
                (order, user) => new
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    Username = user.Username,
                    Email = user.Email
                })
            .ToListAsync();
    }

    // 3. Aggregate sales data - group by product, calculate total sold
    public async Task<IEnumerable<ProductSalesDto>> GetProductSalesAggregation()
    {
        return await context.OrderItems
            .Include(oi => oi.Product)
            .GroupBy(oi => oi.ProductId)
            .Select(g => new ProductSalesDto
            {
                ProductId = g.Key,
                ProductName = g.First().Product.Name,
                TotalSold = g.Sum(x => x.Quantity),
                TotalRevenue = g.Sum(x => x.Quantity * x.Product.Price)
            })
            .OrderByDescending(x => x.TotalSold)
            .ToListAsync();
    }

    // 4. Dashboard projections with select new and anonymous types
    public async Task<object> GetDashboardProjections()
    {
        var totalProducts = await context.Products.CountAsync();
        var totalOrders = await context.Orders.CountAsync();
        var totalUsers = await context.Users.CountAsync();
        
        var cutoffDate = DateTime.UtcNow.AddMonths(-1);
        var monthlyRevenue = await context.OrderItems
            .Where(oi => oi.Order.OrderDate >= cutoffDate)
            .SumAsync(oi => oi.Quantity * oi.Product.Price);

        var topCategories = await context.Products
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                ProductCount = g.Count(),
                AveragePrice = g.Average(p => p.Price)
            })
            .OrderByDescending(x => x.ProductCount)
            .Take(5)
            .ToListAsync();

        var recentOrders = await context.Orders
            .Include(o => o.User)
            .OrderByDescending(o => o.OrderDate)
            .Take(10)
            .Select(o => new
            {
                o.Id,
                o.OrderDate,
                o.Status,
                Username = o.User.Username,
                ItemCount = o.OrderItems.Count()
            })
            .ToListAsync();

        return new
        {
            Summary = new
            {
                TotalProducts = totalProducts,
                TotalOrders = totalOrders,
                TotalUsers = totalUsers,
                MonthlyRevenue = monthlyRevenue
            },
            TopCategories = topCategories,
            RecentOrders = recentOrders
        };
    }

    // 5. Complex query with multiple joins and filtering
    public async Task<IEnumerable<object>> GetOrderDetailsWithProducts()
    {
        return await context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.OrderDate >= DateTime.UtcNow.AddMonths(-3))
            .SelectMany(o => o.OrderItems.Select(oi => new
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                CustomerName = o.User.Username,
                ProductName = oi.Product.Name,
                Category = oi.Product.Category,
                Quantity = oi.Quantity,
                UnitPrice = oi.Product.Price,
                LineTotal = oi.Quantity * oi.Product.Price
            }))
            .OrderByDescending(x => x.OrderDate)
            .ToListAsync();
    }

    // 6. Aggregation with grouping and having clause equivalent
    public async Task<IEnumerable<object>> GetHighValueCustomers()
    {
        var result = await context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .GroupBy(o => new { o.UserId, o.User.Username })
            .Select(g => new
            {
                UserId = g.Key.UserId,
                Username = g.Key.Username,
                TotalOrders = g.Count(),
                TotalSpent = g.SelectMany(o => o.OrderItems)
                           .Sum(oi => oi.Quantity * oi.Product.Price),
                AverageOrderValue = g.SelectMany(o => o.OrderItems)
                                  .Sum(oi => oi.Quantity * oi.Product.Price) / g.Count()
            })
            .ToListAsync();
        
        return result.Where(x => x.TotalSpent > 500) // Having clause equivalent
                    .OrderByDescending(x => x.TotalSpent);
    }
}