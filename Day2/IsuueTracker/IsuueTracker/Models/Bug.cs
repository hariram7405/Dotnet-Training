namespace IsuueTracker.Models
{
    public class Bug : Issue, IReportable
    {
        public string Severity { get; set; }

        public Bug(int id, string title, string assignedto, string severity)
            : base(id, title, assignedto)
        {
            Severity = severity;
        }

        public override void Display()
        {
            Console.WriteLine($"[BUG] #{Id}: {Title} | Severity: {Severity} | Assigned to: {Assignedto}");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"Bug #{Id} is under investigation. It is still in progress.");
        }
    }
}
