using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetFirstAvailableStaffAsync() => throw new NotImplementedException();
        public async Task<User?> GetFirstAvailableRoomAsync() => throw new NotImplementedException();
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<bool> ExistsByUsernameAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}