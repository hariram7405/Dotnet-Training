using System;

namespace SupportPortal.Models
{
    public class SupportRequest
    {
        public int RequestId { get; set; }
        public string Issue { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public double ResolutionTimeInHours { get; set; }
        public bool IsResolved { get; set; }
        public SupportAgent AssignedTo { get; set; }

        public SupportRequest(int requestId, string issue, string status, DateTime createdOn, double resolutionTimeInHours, SupportAgent assignedTo)
        {
            RequestId = requestId;
            Issue = issue;
            Status = status;
            CreatedOn = createdOn;
            ResolutionTimeInHours = resolutionTimeInHours;
            AssignedTo = assignedTo;
            IsResolved = false;
        }

        public void MarkResolved()
        {
            IsResolved = true;
            Status = "Resolved";
        }

        public void Reassign(SupportAgent newAgent)
        {
            AssignedTo = newAgent;
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"\nRequest ID: {RequestId}");
            Console.WriteLine($"Issue: {Issue}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Created On: {CreatedOn}");
            Console.WriteLine($"Resolution Time (hrs): {ResolutionTimeInHours}");
            Console.WriteLine($"Is Resolved: {IsResolved}");
            Console.WriteLine($"Assigned To: {AssignedTo.Name} (ID: {AssignedTo.AgentId})");
        }
    }
}
