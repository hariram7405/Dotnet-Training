using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Core.Interfaces;
using CoreEntities = ShopTrackPro.Core.Entities;
using ShopTrackPro.Infrastructure.Data;

namespace ShopTrackPro.Infrastructure.Repositories;

public class OrderRepository(ShopTrackProContext context) : Repository<CoreEntities.Order>(context), IOrderRepository
{
    public async Task<IEnumerable<CoreEntities.Order>> GetOrdersByUserId(int userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<CoreEntities.Order>> GetOrdersWithItems()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.User)
            .ToListAsync();
    }

    public async Task<CoreEntities.Order?> GetOrderWithItemsById(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}