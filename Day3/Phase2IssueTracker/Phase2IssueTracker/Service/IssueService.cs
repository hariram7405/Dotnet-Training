using System;
using System.Collections.Generic;
using Phase2IssueTracker.Models;

namespace Phase2IssueTracker.Services
{
    public class IssueService : IIssueService
    {cd
        private List<Issue> issues = new List<Issue>();

        public void AddIssue(Issue issue)
        {
            issues.Add(issue);
        }

        public void DisplayAllIssues()
        {
            foreach (var issue in issues)
            {
                issue.Display();
                Console.WriteLine();
            }
        }

        public void ReportAllStatuses()
        {
            foreach (var issue in issues)
            {
                if (issue is IReportable reportable)
                {
                    reportable.ReportStatus();
                    reportable.GetSummary();
                }
                Console.WriteLine();
            }
        }
    }
}
