using System;
using System.Collections.Generic;
using Phase2IssueTracker.Models;
using Phase2IssueTracker.Services;

namespace Phase2IssueTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            IIssueService issueService = new IssueService();
            List<Issue> issues = new List<Issue>();

            var bug1 = new Bug(1, "App crashes on login", "Ravi", "Open", "Critical");
            var task1 = new WorkTask(2, "Page not loading", "Anita", 6);
            var feature1 = new FeatureRequest(3, "Resolve UI feature issue", "Lokesh", "Open", "Sunil", "7 hours");

            issueService.AddIssue(bug1);
            issueService.AddIssue(task1);
            issueService.AddIssue(feature1);

            issues.Add(bug1);
            issues.Add(task1);
            issues.Add(feature1);

            Console.WriteLine("Changing bug1 status to Closed:");
            bug1.ChangeStatus("Closed");

            Console.WriteLine("\nDisplaying all issues:");
            issueService.DisplayAllIssues();

            Console.WriteLine("\nReporting status of all issues:");
            issueService.ReportAllStatuses();

            int openCount = 0;
            int closedCount = 0;
            int inProgressCount = 0;
            int resolvedCount = 0;

            foreach (Issue issue in issues)
            {
                switch (issue.Status)
                {
                    case "Open": openCount++; break;
                    case "Closed": closedCount++; break;
                    case "In Progress": inProgressCount++; break;
                    case "Resolved": resolvedCount++; break;
                }
            }

            Console.WriteLine("Summary of Tickets by Status:");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Open Tickets: {openCount}");
            Console.WriteLine($"Closed Tickets: {closedCount}");
            Console.WriteLine($"In Progress Tickets: {inProgressCount}");
            Console.WriteLine($"Resolved Tickets: {resolvedCount}");

            Console.WriteLine("\nChanging feature1 status to Resolved:");
            feature1.ChangeStatus("Resolved");
        }
    }
}
