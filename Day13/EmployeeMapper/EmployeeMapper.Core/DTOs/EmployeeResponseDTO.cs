namespace EmployeeMapper.Core.DTOs
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Designation { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}
