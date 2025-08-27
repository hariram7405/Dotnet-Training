using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelManagement.Infrastructure.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {

        private readonly AppDBContext _context;
        public StaffRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Staff entity)
        {
            await _context.Staffs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Staff entity)
        {
            _context.Staffs.Update(entity);
            await _context.SaveChangesAsync();

        }
        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staffs.Include(s => s.Students).ToListAsync();
        }

        public async Task DeleteAsync(Staff entity)
        {
            _context.Staffs.Remove(entity);
            await _context.SaveChangesAsync();

        }
        public async Task<Staff?> GetByIdAsync(int id)
        {
            return await _context.Staffs.Include(s => s.Students).FirstOrDefaultAsync(s => s.StaffId == id);
        }

        public async Task<Staff?> GetFirstAvailableStaffAsync()
        {
            return await _context.Staffs.Include(s => s.Students)
                .Where(s => s.Students.Count < 5)
                .OrderBy(s => s.StaffId)
                .FirstOrDefaultAsync();
        }

        public async Task<Staff?> GetFirstAvailableRoomAsync() => throw new NotImplementedException();
        public async Task<Staff?> GetByUsernameAsync(string username) => throw new NotImplementedException();
        public async Task<bool> ExistsByUsernameAsync(string username) => throw new NotImplementedException();

    }
}

