using EmployeeMapper.Core.DTOs;
using EmployeeMapper.Core.Entities;
using System.Collections.Generic;

namespace EmployeeMapper.Core.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentRequestDTO dto);
        void DeleteDepartment(int id);
        void UpdateDepartment(DepartmentRequestDTO dto);
        Department? GetDepartmentById(int id);
        int GetDepartmentCount();
        void DisplayDepartment();
      bool  Exists(int id);
    }
}
