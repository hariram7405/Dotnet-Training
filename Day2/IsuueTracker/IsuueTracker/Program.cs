using System;
using System.Collections.Generic;
using IsuueTracker.Models;

List<Issue> issues = new List<Issue>();

Bug bug1 = new Bug(1, "App crashes on login", "Ravi", "Critical");
WorkTask task1 = new WorkTask(2, "Page not loading", "Anita", 6);


issues.Add(bug1);
issues.Add(task1);

Console.WriteLine("All Issues:\n");

foreach (Issue issue in issues)
{
    issue.Display();

    if (issue is IReportable reportable)
    {
        reportable.ReportStatus();
    }

    Console.WriteLine();
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
