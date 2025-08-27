namespace HostelManagement.MVC.Models
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<string> Students { get; set; } = new List<string>();
    }
}