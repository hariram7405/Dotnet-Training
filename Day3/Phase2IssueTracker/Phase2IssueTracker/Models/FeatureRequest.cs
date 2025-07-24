using System;

namespace Phase2IssueTracker.Models
{
    public class FeatureRequest : Issue, IReportable
    {
        public string RequestedBy { get; set; }
        public string Deadline { get; set; }

        public FeatureRequest(int id, string title, string assignedTo, string status, string requestedBy, string deadline)
            : base(id, title, assignedTo)
        {
            Status = status;
            RequestedBy = requestedBy;
            Deadline = deadline;
        }

        public override void Display()
        {
            Console.WriteLine($"[Feature] #{Id}: {Title} | Requested By: {RequestedBy} | Deadline: {Deadline} | Assigned to: {Assignedto} | Status: {Status}");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"Feature Request #{Id} is being reviewed. Deadline: {Deadline}");
        }

        public void GetSummary()
        {
            Console.WriteLine("Summary");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Feature Id: {Id}");
            Console.WriteLine($"Feature Title: {Title}");
            Console.WriteLine($"Requested By: {RequestedBy}");
            Console.WriteLine($"Feature AssignedTo: {Assignedto}");
            Console.WriteLine($"Feature Status: {Status}");
            Console.WriteLine($"Feature Deadline: {Deadline}");
            Console.WriteLine($"Summary Generated on: {DateTime.Now}");
        }
    }
}
