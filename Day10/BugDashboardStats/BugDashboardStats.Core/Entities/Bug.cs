namespace BugDashboardStats.Core.Entities;

public class Bug
{
    public string Title { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime CreatedDate { get; set; }

    public Project Project { get; set; }
    public User AssignedTo { get; set; }
}
