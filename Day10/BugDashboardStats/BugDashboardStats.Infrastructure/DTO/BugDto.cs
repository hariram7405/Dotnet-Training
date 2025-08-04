namespace BugDashboardStats.Infrastructure.DTOs;

public class BugDto
{
    public string Title { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string ProjectName { get; set; }
    public string AssignedTo { get; set; }
    public DateTime CreatedDate { get; set; }
}
