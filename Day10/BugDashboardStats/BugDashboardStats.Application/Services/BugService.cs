using BugDashboardStats.Core.Entities;
using BugDashboardStats.Core.Interfaces;
using BugDashboardStats.Infrastructure.DTOs;

namespace BugDashboardStats.Application.Services;

public class BugService
{
    private readonly IBugRepository _repo;

    public BugService(IBugRepository repo)
    {
        _repo = repo;
    }

    // 1. View All Bugs
    public List<BugDto> GetAllBugs() =>
        _repo.GetAllBugs().Select(MapToDto).ToList();

    // 2. View Bugs by Project
    public List<BugDto> GetBugsByProject(string projectName) =>
        _repo.GetAllBugs()
             .Where(b => b.Project.Name.Equals(projectName, StringComparison.OrdinalIgnoreCase))
             .Select(MapToDto)
             .ToList();

    // 3. View Bugs by Status
    public List<BugDto> GetBugsByStatus(string status) =>
        _repo.GetAllBugs()
             .Where(b => b.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
             .Select(MapToDto)
             .ToList();

    // 4. View Bugs by Priority
    public List<BugDto> GetBugsByPriority(string priority) =>
        _repo.GetAllBugs()
             .Where(b => b.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase))
             .Select(MapToDto)
             .ToList();

    // 5. View All Bugs Sorted by Created Date
    public List<BugDto> GetAllBugsSortedByDate() =>
        _repo.GetAllBugs()
             .OrderBy(b => b.CreatedDate)
             .Select(MapToDto)
             .ToList();

    // 6. Group by Status
    public List<BugGroupedStatsDto> GroupBugsByStatus()
    {
        var bugs = _repo.GetAllBugs();
        return bugs.GroupBy(b => b.Status)
                   .Select(g => new BugGroupedStatsDto { GroupName = g.Key, Count = g.Count() })
                   .ToList();
    }

    // 7. Group by Priority
    public List<BugGroupedStatsDto> GroupBugsByPriority()
    {
        var bugs = _repo.GetAllBugs();
        return bugs.GroupBy(b => b.Priority)
                   .Select(g => new BugGroupedStatsDto { GroupName = g.Key, Count = g.Count() })
                   .ToList();
    }

    // 8. Group by Project
    public List<BugGroupedStatsDto> GroupBugsByProject()
    {
        var bugs = _repo.GetAllBugs();
        return bugs.GroupBy(b => b.Project.Name)
                   .Select(g => new BugGroupedStatsDto { GroupName = g.Key, Count = g.Count() })
                   .ToList();
    }

    // 9. Show All Grouped Stats (by Project, Priority, Status)
    public (List<BugGroupedStatsDto> byProject, List<BugGroupedStatsDto> byPriority, List<BugGroupedStatsDto> byStatus) GetAllGroupedStats()
    {
        return (GroupBugsByProject(), GroupBugsByPriority(), GroupBugsByStatus());
    }

    private static BugDto MapToDto(Bug b) => new()
    {
        Title = b.Title,
        Status = b.Status,
        Priority = b.Priority,
        ProjectName = b.Project.Name,
        AssignedTo = b.AssignedTo.Name,
        CreatedDate = b.CreatedDate
    };
}
