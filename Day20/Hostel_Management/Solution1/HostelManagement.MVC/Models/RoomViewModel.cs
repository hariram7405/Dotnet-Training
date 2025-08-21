namespace HostelManagement.MVC.Models
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<string> Students { get; set; } = new List<string>();
    }
}