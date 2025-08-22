using HostelManagement.Core.Interfaces;
using HostelManagement.Core.Entities;
using HostelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Infrastructure.Repositories
{
   public class RoomRepository:IRepository<Room>
    {
        private readonly AppDBContext _context;
        public RoomRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Room entity) {
           await _context.Rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync( Room entity) {
            _context.Rooms.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<Room?> GetByIdAsync(int id) {
            return await _context.Rooms.Include(r => r.Students).FirstOrDefaultAsync(s => s.RoomId == id);

        }
       
        public async Task<IEnumerable<Room>> GetAllAsync() {
            return await _context.Rooms
             .Include(r => r.Students)
             .ToListAsync();
        }

        public async Task DeleteAsync(Room entity) {
           _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
