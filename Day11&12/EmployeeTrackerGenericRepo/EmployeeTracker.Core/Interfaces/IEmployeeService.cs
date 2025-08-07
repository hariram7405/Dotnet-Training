using EmployeeTracker.Core.Entities;
using System.Collections.Generic;

namespace EmployeeTracker.Core.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        IEnumerable<Employee> GetAll();
       
        IEnumerable<Employee> GetEmployeesByDepartment(int departmentId);
        int GetEmployeeCount();
        void DisplayEmployee();
        int Exists(int id);
    }
}
