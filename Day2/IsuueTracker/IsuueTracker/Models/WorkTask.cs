namespace IsuueTracker.Models
{
    internal class WorkTask : Issue, IReportable
    {
        public int EstimatedHours { get; set; }
        

        public WorkTask(int id, string title, string assignedTo, int estimatedHours)
            : base(id, title, assignedTo)
        {
            EstimatedHours = estimatedHours;
        }

        public override void Display()
        {
            Console.WriteLine($"[Task] #{Id}: {Title} | Estimated Hours: {EstimatedHours} | Assigned to: {Assignedto}");
        }

        public void ReportStatus()
        {
            Console.WriteLine($"Task #{Id} is in progress. Estimated time: {EstimatedHours} hours.");
        }
    }
}
