using EmployeeMapper.Core.Entities;
using System.Collections.Generic;

namespace EmployeeMapper.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesByDepartment(int departmentId);
    }
}
