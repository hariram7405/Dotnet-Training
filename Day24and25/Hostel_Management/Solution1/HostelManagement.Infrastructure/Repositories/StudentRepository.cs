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
   public class StudentRepository:IRepository<Student>
    {

        private readonly AppDBContext _context;
        public StudentRepository(AppDBContext context)
        {
            _context = context;
        }
       public async   Task AddAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
         _context.Students.Update(entity);
            await _context.SaveChangesAsync();

        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(s => s.Room)
        .Include(s => s.Staff).ToListAsync();
        }

        public async Task DeleteAsync(Student entity)
        {
             _context.Students.Remove(entity);
            await _context.SaveChangesAsync();

        }
        public async Task<Student?>GetByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Room)
        .Include(s => s.Staff).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> GetFirstAvailableStaffAsync() => throw new NotImplementedException();
        public async Task<Student?> GetFirstAvailableRoomAsync() => throw new NotImplementedException();
        public async Task<Student?> GetByUsernameAsync(string username) => throw new NotImplementedException();
        public async Task<bool> ExistsByUsernameAsync(string username) => throw new NotImplementedException();

    }
}

       