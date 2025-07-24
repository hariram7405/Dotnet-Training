using System;

namespace Phase2IssueTracker.Models
{
    public class WorkTask : Issue, IReportable
    {
        public int EstimatedHours { get; set; }

        public WorkTask(int id, string title, string assignedTo, int estimatedHours)
            : base(id, title, assignedTo)
        {
            EstimatedHours = estimatedHours;
        }

        public override void Display()
        {
            Console.WriteLine($"[Task] #{Id}: {Title} | Estimated Hours: {EstimatedHours} | Assigned to: {Assignedto} | Status: {Status}");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"Task #{Id} is in progress. Estimated time: {EstimatedHours} hours.");
        }

        public void GetSummary()
        {
            Console.WriteLine("Summary");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Task Id: {Id}");
            Console.WriteLine($"Task Title: {Title}");
            Console.WriteLine($"Task AssignedTo: {Assignedto}");
            Console.WriteLine($"Task Status: {Status}");
            Console.WriteLine($"Task EstimationTime: {EstimatedHours} hours");
            Console.WriteLine($"Summary Generated on: {DateTime.Now}");
        }
    }
}
