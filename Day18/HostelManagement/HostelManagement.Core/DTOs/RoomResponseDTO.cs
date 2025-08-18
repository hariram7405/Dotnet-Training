namespace HostelManagement.Core.DTOs
{
    public class RoomResponseDTO
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<string> StudentNames { get; set; } = new();
    }
}
