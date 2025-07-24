using System;

namespace Phase2IssueTracker.Models
{
    public class Bug : Issue, IReportable
    {
        public string Severity { get; set; }

        public Bug(int id, string title, string assignedto, string status, string severity)
            : base(id, title, assignedto)
        {
            Severity = severity;
           
        }

        public override void Display()
        {
            Console.WriteLine($"[BUG] #{Id}: {Title} | Severity: {Severity} | Assigned to: {Assignedto} | Status: {status}");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"Bug #{Id} is under investigation. It is still in progress.");
        }

        public void GetSummary()
        {
            Console.WriteLine("Summary");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Bug Id: {Id}");
            Console.WriteLine($"Bug Title: {Title}");
            Console.WriteLine($"Bug Severity: {Severity}");
            Console.WriteLine($"Bug AssignedTo: {Assignedto}");
            Console.WriteLine($"Bug Status: {status}");
            Console.WriteLine($"Summary Generated on: {DateTime.Now}");
        }
    }
}
