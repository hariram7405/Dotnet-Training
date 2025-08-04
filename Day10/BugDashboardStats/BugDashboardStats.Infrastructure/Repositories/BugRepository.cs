using BugDashboardStats.Core.Entities;
using BugDashboardStats.Core.Interfaces;

namespace BugDashboardStats.Infrastructure.Repositories;

public class BugRepository : IBugRepository
{
    public List<Bug> GetAllBugs()
    {
        var user1 = new User { Name = "Alice" };
        var user2 = new User { Name = "Bob" };

        var project1 = new Project { Name = "Website Redesign" };
        var project2 = new Project { Name = "Mobile App" };

        return new List<Bug>
        {
            new Bug { Title = "Login fails", Status = "Open", Priority = "High", CreatedDate = DateTime.Today.AddDays(-5), AssignedTo = user1, Project = project1 },
            new Bug { Title = "UI not responsive", Status = "In Progress", Priority = "Medium", CreatedDate = DateTime.Today.AddDays(-2), AssignedTo = user2, Project = project2 },
            new Bug { Title = "Crash on submit", Status = "Closed", Priority = "High", CreatedDate = DateTime.Today.AddDays(-10), AssignedTo = user1, Project = project1 },
            new Bug { Title = "Data not saving", Status = "Open", Priority = "Low", CreatedDate = DateTime.Today.AddDays(-1), AssignedTo = user2, Project = project2 }
        };
    }
}
