using ShopTrackPro.Core.Entities;

namespace ShopTrackPro.Core.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategory(string category);
    Task<IEnumerable<Product>> GetProductsSortedByPrice(bool ascending = true);
    Task<IEnumerable<Product>> SearchProducts(string searchTerm);
}