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
 public  class DepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public void AddDepartment(Department d)
        {
            _repository.Add(d);
        }
        public void UpdateDepartment(Department d)
        {
            _repository.Update(d);
        }
        public void DeleteDepartment(int id)
        {
            _repository.Delete(id);
        }
        public IEnumerable<Department> GetAll()
        {
            return _repository.GetAll();
        }
        public Department? GetDepartmentById(int id)
        {
            return _repository.GetById(id);
        }
        public int GetDepartmentCount()
        {
            return _repository.Counts();
        }
        public void DisplayDepartment()
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
