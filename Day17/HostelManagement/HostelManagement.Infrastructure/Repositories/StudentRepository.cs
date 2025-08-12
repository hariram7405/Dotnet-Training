using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;

namespace HostelManagement.Infrastructure.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly List<Student> _students = new List<Student>();
        private int _nextId = 1000;

        public void Add(Student entity)
        {
            _nextId++;
            entity.Id = _nextId;
            _students.Add(entity);
        }

        public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public IEnumerable<Student> GetAll() => _students;
        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}
