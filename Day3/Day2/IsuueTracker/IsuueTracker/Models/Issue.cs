namespace IsuueTracker.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Assignedto { get; set; }

        public Issue(int id, string title, string assignedto)
        {
            Id = id;
            Title = title;
            Assignedto = assignedto;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Issue #{Id}: {Title} Assigned to {Assignedto}");
        }
    }
}
