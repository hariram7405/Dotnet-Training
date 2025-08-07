using EmployeeTracker.Core.Entities;
using System.Collections.Generic;

namespace EmployeeTracker.Core.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        IEnumerable<Department> GetAll();
        Department? GetDepartmentById(int id);
        int GetDepartmentCount();
        void DisplayDepartment();
        int Exists(int id);
    }
}
