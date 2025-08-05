using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTracker.Core.Interfaces;
using EmployeeTracker.Core.Entities;


namespace EmployeeTracker.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();
    
    public void Add(Employee entity) {
            _employees.Add(entity);
        }
        public void Update(Employee entity)
        {
            var emp = GetById(entity.Id);
            if (emp != null)
            {
                emp.Name = entity.Name;
                emp.Designation = entity.Designation;
                emp.DepartmentId = entity.DepartmentId;
                emp.Salary = entity.Salary;
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public void Delete(int id) {
            var empid = GetById(id);
            if (empid != null) {
                _employees.Remove(empid);
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
           public  Employee? GetById(int id) {
                return _employees.FirstOrDefault(e => e.Id == id);
            }
           public  IEnumerable<Employee> GetAll() {
                return _employees;

            }
        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentId)
        {
            return _employees.Where(e => e.DepartmentId == departmentId);
        }

        public int Counts()
        {
            return _employees.Count;
        }
        public void Display()
        {
            if (_employees == null)
            {
                Console.WriteLine("Departments list is Empty");
            }
            else
            {
                Console.WriteLine("\n--- Employee List ---\n");
                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-10} {4,10}", "ID", "Name", "Designation", "DeptId", "Salary");
                Console.WriteLine(new string('-', 70));

                foreach (var emp in _employees)
                {
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-10} {4,10:C}", emp.Id, emp.Name, emp.Designation, emp.DepartmentId, emp.Salary);
                }
            }
        }
    }
    }