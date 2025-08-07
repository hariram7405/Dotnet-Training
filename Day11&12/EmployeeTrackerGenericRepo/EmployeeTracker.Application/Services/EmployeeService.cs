using EmployeeTracker.Core.Entities;
using EmployeeTracker.Core.Interfaces;
using EmployeeTracker.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Application.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
        }
        public void DeleteEmployee(int id)
        {
            _repository.Delete(id);
        }
        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }
    public Employee? GetDepartmentById(int id)
        {
            return _repository.GetById(id);
        }
        public IEnumerable<Employee> GetEmployeesByDepartment(int departmentId)
        {
            return _repository.GetEmployeesByDepartment(departmentId);
        }

        public int GetEmployeeCount()
        {
            return _repository.Counts();
        }
        public void DisplayEmployee()
        {
            _repository.Display();
        }
        public int Exists(int id)
        {
            var x = _repository.GetById(id);
            return (x == null) ? 1 : 0;
        }
    }
}
