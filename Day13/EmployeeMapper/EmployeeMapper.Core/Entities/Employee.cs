using System;

namespace EmployeeMapper.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Designation { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}
