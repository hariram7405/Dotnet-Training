namespace HostelManagement.Core.DTOs
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;

        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
    }
}
