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
            
           

          

            foreach (Issue issue in issues)
            {
                issue.Display();

                if (issue is IReportable reportable)
                {
                    reportable.ReportStatus();
                    reportable.GetSummary();
                }

                Console.WriteLine();
            }

            Console.WriteLine("Changing feature1 status to Resolved:");
            feature1.changeStatus("Resolved");

            
        }
    }
}
