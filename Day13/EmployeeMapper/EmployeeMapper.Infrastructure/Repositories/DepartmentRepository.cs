using EmployeeMapper.Core.Entities;
using EmployeeMapper.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMapper.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly List<Department> _departments = new();
        private  int seedId = 0;

        public void Add(Department entity)
        {
            seedId++;
            entity.Id = seedId;
            _departments.Add(entity);
        }

        public void Update(Department entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
                _departments.Remove(existing);
        }

        public Department? GetById(int id) =>
            _departments.FirstOrDefault(d => d.Id == id);

        public int Counts() => _departments.Count;

        public void Display()
        {
            if (_departments.Count == 0) return;

            System.Console.WriteLine("\n--- Departments ---");
            System.Console.WriteLine("{0,-5} {1,-20}", "ID", "Name");
            System.Console.WriteLine(new string('-', 30));

            foreach (var d in _departments)
                System.Console.WriteLine("{0,-5} {1,-20}", d.Id, d.Name);
        }
    }
}
