using Phase2IssueTracker.Models;

namespace Phase2IssueTracker.Services
{
    public interface IIssueService
    {
        void AddIssue(Issue issue);
        void DisplayAllIssues();
        void ReportAllStatuses();
    }
}
