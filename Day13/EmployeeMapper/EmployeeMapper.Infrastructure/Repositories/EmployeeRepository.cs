using EmployeeMapper.Core.Entities;
using EmployeeMapper.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMapper.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();
        private int  seedId = 0;

        public void Add(Employee entity)
        {
            seedId++;
            entity.Id = seedId;
            _employees.Add(entity);
        }

        public void Update(Employee entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Designation = entity.Designation;
                existing.DepartmentId = entity.DepartmentId;
                existing.Salary = entity.Salary;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
                _employees.Remove(existing);
        }

        public Employee? GetById(int id) =>
            _employees.FirstOrDefault(e => e.Id == id);

        public int Counts() => _employees.Count;

        public void Display()
        {
            if (_employees.Count == 0) return;

            System.Console.WriteLine("\n--- Employees ---");
            System.Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-10} {4,10}", "ID", "Name", "Designation", "DeptId", "Salary");
            System.Console.WriteLine(new string('-', 70));

            foreach (var e in _employees)
                System.Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-10} {4,10:C}", e.Id, e.Name, e.Designation, e.DepartmentId, e.Salary);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }
        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentId) =>
            _employees.Where(e => e.DepartmentId == departmentId);
    }

}
