namespace HostelManagement.Core.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int Capacity { get; set; } = 5;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
