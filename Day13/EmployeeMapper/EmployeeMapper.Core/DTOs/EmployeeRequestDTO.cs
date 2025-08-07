namespace EmployeeMapper.Core.DTOs
{
    public class EmployeeRequestDTO
    {
        public required string Name { get; set; }
        public required string Designation { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}
