using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Core.Interfaces;
using CoreEntities = ShopTrackPro.Core.Entities;
using ShopTrackPro.Infrastructure.Data;


namespace ShopTrackPro.Infrastructure.Repositories;

public class ProductRepository(ShopTrackProContext context) : Repository<CoreEntities.Product>(context), IProductRepository
{
    public async Task<IEnumerable<CoreEntities.Product>> GetByCategory(string category)
    {
        return await _context.Products.Where(p => p.Category == category).Select(p => new CoreEntities.Product
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Category = p.Category
        }).ToListAsync();
    }

    public async Task<IEnumerable<CoreEntities.Product>> GetProductsSortedByPrice(bool ascending = true)
    {
        var query = _context.Products.Select(p => new CoreEntities.Product
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Category = p.Category
        });
        
        return ascending 
            ? await query.OrderBy(p => p.Price).ToListAsync()
            : await query.OrderByDescending(p => p.Price).ToListAsync();
    }

    public async Task<IEnumerable<CoreEntities.Product>> SearchProducts(string searchTerm)
    {
        return await _context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .Select(p => new CoreEntities.Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category
            }).ToListAsync();
    }
}