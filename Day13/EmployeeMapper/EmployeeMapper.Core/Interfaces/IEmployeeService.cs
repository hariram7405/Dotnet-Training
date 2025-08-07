using EmployeeMapper.Core.DTOs;
using System.Collections.Generic;

namespace EmployeeMapper.Core.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeRequestDTO dto);
        void DeleteEmployee(int id);
        void UpdateEmployee(EmployeeRequestDTO dto);

        
        IEnumerable<EmployeeResponseDTO> GetAllEmployees();
        IEnumerable<EmployeeResponseDTO> GetEmployeesByDepartment(int departmentId);

        int GetEmployeeCount();
        void DisplayEmployee();
       bool Exists(int id);
    }
}
