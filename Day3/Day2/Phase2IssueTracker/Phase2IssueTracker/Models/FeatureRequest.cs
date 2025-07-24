using System;

namespace Phase2IssueTracker.Models
{
    public class FeatureRequest : Issue, IReportable
    {
        public string requestedBy;
        public string releaseDate;

        public FeatureRequest(int id, string title, string assignedto, string status, string requestedBy, string releaseDate)
            : base(id, title, assignedto)
        {
            this.requestedBy = requestedBy;
            this.releaseDate = releaseDate;
          
        }

        public override void Display()
        {
            Console.WriteLine($"[Feature] #{Id}: {Title} | Assigned to: {Assignedto} | Requested By: {requestedBy} | Release Date: {releaseDate} | Status: {status}");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"Feature Request #{Id} is ongoing. It is still in progress.");
        }

        public void GetSummary()
        {
            Console.WriteLine("Summary");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Feature Id: {Id}");
            Console.WriteLine($"Feature Title: {Title}");
            Console.WriteLine($"Feature AssignedTo: {Assignedto}");
            Console.WriteLine($"Feature Status: {status}");
            Console.WriteLine($"Feature RequestedBy: {requestedBy}");
            Console.WriteLine($"Feature ReleaseDate: {releaseDate}");
            Console.WriteLine($"Summary Generated on: {DateTime.Now}");
        }
    }
}
