namespace HostelManagement.Core.DTOs
{
    public class StaffResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<string> StudentNames { get; set; } = new();
    }
}
