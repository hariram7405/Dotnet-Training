namespace Day1Proj1phase2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        public void DisplayUser()
        {
            Console.WriteLine($"User: {Name}, Role: {Role}");
        }
    }
}
