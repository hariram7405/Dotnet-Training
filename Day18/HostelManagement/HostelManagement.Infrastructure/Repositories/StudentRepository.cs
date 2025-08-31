using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Infrastructure.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public Student? GetById(int id) => _context.Students
            .Include(s => s.Room)
            .Include(s => s.Staff)
            .FirstOrDefault(s => s.Id == id);

        public IEnumerable<Student> GetAll() => _context.Students
            .Include(s => s.Room)
            .Include(s => s.Staff)
            .ToList();

        public void Update(Student entity)
        {
            _context.Students.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
