namespace ShopTrackPro.MVC.Models;

public class AnalyticsDashboardViewModel
{
    public DashboardSummary Summary { get; set; } = new();
    public List<CategoryInfo> TopCategories { get; set; } = new();
    public List<RecentOrderInfo> RecentOrders { get; set; } = new();
}

public class DashboardSummary
{
    public int TotalProducts { get; set; }
    public int TotalOrders { get; set; }
    public int TotalUsers { get; set; }
    public decimal MonthlyRevenue { get; set; }
}

public class CategoryInfo
{
    public string Category { get; set; } = string.Empty;
    public int ProductCount { get; set; }
    public decimal AveragePrice { get; set; }
}

public class RecentOrderInfo
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public int ItemCount { get; set; }
}

public class CustomerAnalysisViewModel
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public int TotalOrders { get; set; }
    public decimal TotalSpent { get; set; }
    public decimal AverageOrderValue { get; set; }
}

public class OrderDetailsViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}