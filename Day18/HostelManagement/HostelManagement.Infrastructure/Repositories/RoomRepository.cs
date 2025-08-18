using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Infrastructure.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
        }

        public Room? GetById(int id) => _context.Rooms
            .Include(r => r.Students)
            .FirstOrDefault(r => r.Id == id);

        public IEnumerable<Room> GetAll() => _context.Rooms
            .Include(r => r.Students)
            .ToList();

        public void Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
