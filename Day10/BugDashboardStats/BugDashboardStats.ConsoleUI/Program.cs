using System;
using System.Collections.Generic;
using System.Linq;
using BugDashboardStats.Application.Services;
using BugDashboardStats.Core.Interfaces;
using BugDashboardStats.Infrastructure.DTOs;
using BugDashboardStats.Infrastructure.Repositories;

public class Program
{
    private static readonly string[] ValidStatuses = { "Open", "Closed", "In Progress" };
    private static readonly string[] ValidPriorities = { "High", "Medium", "Low" };

    public static void Main(string[] args)
    {
        IBugRepository bugRepository = new BugRepository();
        var bugService = new BugService(bugRepository);

        while (true)
        {
            Console.WriteLine("\nBug Stats Dashboard");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. View All Bugs");
            Console.WriteLine("2. View Bugs by Project");
            Console.WriteLine("3. View Bugs by Status");
            Console.WriteLine("4. View Bugs by Priority");
            Console.WriteLine("5. View All Bugs Sorted by Created Date");
            Console.WriteLine("6. Group by Status");
            Console.WriteLine("7. Group by Priority");
            Console.WriteLine("8. Group by Project");
            Console.WriteLine("9. Show All Grouped Stats");
            Console.WriteLine("10. Exit");

            Console.Write("\nSelect an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayBugs(bugService.GetAllBugs(), "All Bugs");
                    break;

                case "2":
                    Console.Write("Enter project name: ");
                    string project = Console.ReadLine();
                    var bugsByProject = bugService.GetBugsByProject(project);
                    DisplayBugs(bugsByProject, $"Bugs for Project '{project}'");
                    break;

                case "3":
                    Console.Write("Enter status (Open, Closed, In Progress): ");
                    string status = Console.ReadLine();
                    if (!ValidStatuses.Any(s => s.Equals(status, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"Invalid status. Valid options: {string.Join(", ", ValidStatuses)}");
                        break;
                    }
                    var bugsByStatus = bugService.GetBugsByStatus(ToTitleCase(status));
                    DisplayBugs(bugsByStatus, $"Bugs with Status '{ToTitleCase(status)}'");
                    break;

                case "4":
                    Console.Write("Enter priority (High, Medium, Low): ");
                    string priority = Console.ReadLine();
                    if (!ValidPriorities.Any(p => p.Equals(priority, StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine($"Invalid priority. Valid options: {string.Join(", ", ValidPriorities)}");
                        break;
                    }
                    var bugsByPriority = bugService.GetBugsByPriority(ToTitleCase(priority));
                    DisplayBugs(bugsByPriority, $"Bugs with Priority '{ToTitleCase(priority)}'");
                    break;

                case "5":
                    var sortedBugs = bugService.GetAllBugsSortedByDate();
                    DisplayBugs(sortedBugs, "All Bugs (Sorted by Created Date)");
                    break;

                case "6":
                    var groupStatus = bugService.GroupBugsByStatus();
                    DisplayGroupStats(groupStatus, "Bug Count by Status");
                    break;

                case "7":
                    var groupPriority = bugService.GroupBugsByPriority();
                    DisplayGroupStats(groupPriority, "Bug Count by Priority");
                    break;

                case "8":
                    var groupProject = bugService.GroupBugsByProject();
                    DisplayGroupStats(groupProject, "Bug Count by Project");
                    break;

                case "9":
                    var (byProject, byPriority, byStatus) = bugService.GetAllGroupedStats();
                    DisplayGroupStats(byProject, "Bug Count by Project");
                    DisplayGroupStats(byPriority, "Bug Count by Priority");
                    DisplayGroupStats(byStatus, "Bug Count by Status");
                    break;

                case "10":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayBugs(List<BugDto> bugs, string title)
    {
        Console.WriteLine($"\n=== {title} ===");

        if (bugs.Count == 0)
        {
            Console.WriteLine("No bugs found.");
            return;
        }

        Console.WriteLine(new string('-', 120));
        Console.WriteLine($"{"Title",-25} {"Project",-20} {"Assigned To",-15} {"Status",-15} {"Priority",-10} {"Created",-10}");
        Console.WriteLine(new string('-', 120));

        foreach (var bug in bugs)
        {
            Console.WriteLine($"{bug.Title,-25} {bug.ProjectName,-20} {bug.AssignedTo,-15} {bug.Status,-15} {bug.Priority,-10} {bug.CreatedDate.ToShortDateString(),-10}");
        }

        Console.WriteLine(new string('-', 120));
    }

    private static void DisplayGroupStats(List<BugGroupedStatsDto> groups, string title)
    {
        Console.WriteLine($"\n=== {title} ===");

        if (groups.Count == 0)
        {
            Console.WriteLine("No grouped data found.");
            return;
        }

        Console.WriteLine($"{"Key",-25} {"Count"}");
        Console.WriteLine(new string('-', 35));
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.GroupName,-25} {group.Count}");
        }
    }

    private static string ToTitleCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return input;
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }
}

/*[media pointer="file-service://file-3WkwaDeLTYKrCujbL4Ym4Y"]
readme file
