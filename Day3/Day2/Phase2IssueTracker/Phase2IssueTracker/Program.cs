using System;
using System.Collections.Generic;
using Phase2IssueTracker.Models;

namespace Phase2IssueTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Issue> issues = new List<Issue>();

            Bug bug1 = new Bug(1, "App crashes on login", "Ravi", "Open", "Critical");
            WorkTask task1 = new WorkTask(2, "Page not loading", "Anita", 6);
            FeatureRequest feature1 = new FeatureRequest(3, "Resolve UI feature issue", "Lokesh", "Open", "Sunil", "7hours");

            issues.Add(bug1);
            issues.Add(task1);
            issues.Add(feature1);

            Console.WriteLine("Changing bug1 status to Closed:");
            bug1.changeStatus("Closed");

            // Counters for issue statuses
            int openCount = 0;
            int closedCount = 0;
            int inProgressCount = 0;
            int resolvedCount = 0;

            foreach (Issue issue in issues)
            {
                issue.Display();

                // Count status
                switch (issue.status)
                {
                    case "Open":
                        openCount++;
                        break;
                    case "Closed":
                        closedCount++;
                        break;
                    case "In Progress":
                        inProgressCount++;
                        break;
                    case "Resolved":
                        resolvedCount++;
                        break;
                }

                if (issue is IReportable reportable)
                {
                    reportable.ReportStatus();
                    reportable.GetSummary();
                }

                Console.WriteLine();
            }

            Console.WriteLine("Summary of Tickets by Status:");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Open Tickets: {openCount}");
            Console.WriteLine($"Closed Tickets: {closedCount}");
            Console.WriteLine($"In Progress Tickets: {inProgressCount}");
            Console.WriteLine($"Resolved Tickets: {resolvedCount}");
            Console.WriteLine();

            Console.WriteLine("Changing feature1 status to Resolved:");
            feature1.changeStatus("Resolved");

           
        }
    }
}
