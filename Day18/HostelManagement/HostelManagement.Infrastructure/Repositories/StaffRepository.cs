using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Infrastructure.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {
        private readonly AppDbContext _context;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Staff entity)
        {
            _context.Staffs.Add(entity);
            _context.SaveChanges();
        }

        public Staff? GetById(int id) => _context.Staffs
            .Include(s => s.Students)
            .FirstOrDefault(s => s.Id == id);

        public IEnumerable<Staff> GetAll() => _context.Staffs
            .Include(s => s.Students)
            .ToList();

        public void Delete(int id)
        {
            var staff = _context.Staffs.Find(id);
            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                _context.SaveChanges();
            }
        }
    }
}
