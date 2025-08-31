using ShopTrackPro.Core.DTOs.Dashboard;

namespace ShopTrackPro.Core.Interfaces;

public interface IAdvancedQueryRepository
{
    Task<IEnumerable<object>> GetProductsByCategoryAndPrice(string category, bool ascending = true);
    Task<IEnumerable<object>> GetOrdersWithUserDetails();
    Task<IEnumerable<ProductSalesDto>> GetProductSalesAggregation();
    Task<object> GetDashboardProjections();
    Task<IEnumerable<object>> GetOrderDetailsWithProducts();
    Task<IEnumerable<object>> GetHighValueCustomers();
}