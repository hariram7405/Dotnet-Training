using AutoMapper;
using BugTracker.Application.Mapping;
using BugTracker.Application.Services;
using BugTracker.Core.DTOs;
using BugTracker.Infrastructure.Repositories;

using System;

class Program
{
    static void Main(string[] args)
    {


        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        IMapper mapper = config.CreateMapper();



        // Create repositories
        var bugRepo = new BugRepository();
        var projectRepo = new ProjectRepository();

        // Create services
        var bugService = new BugService(bugRepo, mapper);
        var projectService = new ProjectService(projectRepo, mapper);

        while (true)
        {
            Console.WriteLine("\n--- Bug Tracker Menu ---");
            Console.WriteLine("1. Add Bug");
            Console.WriteLine("2. Add Project");
            Console.WriteLine("3. View all Bugs");
            Console.WriteLine("4. View all Projects");
            Console.WriteLine("5. Update Bug");
            Console.WriteLine("6. Update Project");
            Console.WriteLine("7. Delete Bug");
            Console.WriteLine("8. Delete Project");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBug(bugService);
                    break;
                case "2":
                    AddProject(projectService);
                    break;
                case "3":
                    bugService.GetAllBugs();
                    break;
                case "4":
                    projectService.GetAllProjects();
                    break;
                case "5":
                    UpdateBug(bugService);
                    break;
                case "6":
                    UpdateProject(projectService);
                    break;
                case "7":
                    DeleteBug(bugService);
                    break;
                case "8":
                    DeleteProject(projectService);
                    break;
                case "9":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddBug(BugService bugService)
    {
        Console.Write("Enter Bug Title: ");
        var title = Console.ReadLine();

        Console.Write("Enter Bug Description: ");
        var description = Console.ReadLine();

        Console.Write("Enter Project Id: ");
        if (!int.TryParse(Console.ReadLine(), out int projectId))
        {
            Console.WriteLine("Invalid Project Id.");
            return;
        }

        Console.Write("Enter Due Date (yyyy-MM-dd) or leave blank: ");
        var dueDateStr = Console.ReadLine();
        DateTime? dueDate = null;
        if (!string.IsNullOrWhiteSpace(dueDateStr))
        {
            if (DateTime.TryParse(dueDateStr, out var dt))
                dueDate = dt;
            else
            {
                Console.WriteLine("Invalid date format.");
                return;
            }
        }

        var bugDto = new BugRequestDTO
        {
            Title = title ?? "",
            Description = description ?? "",
            ProjectId = projectId,
            DueDate = dueDate
        };

        bugService.AddBug(bugDto);
        Console.WriteLine("Bug added successfully.");
    }

    static void AddProject(ProjectService projectService)
    {
        Console.Write("Enter Project Name: ");
        var name = Console.ReadLine();

        Console.Write("Enter Project Description: ");
        var description = Console.ReadLine();

        var projDto = new ProjectRequestDTO
        {
            Name = name ?? "",
            Description = description ?? ""
        };

        projectService.AddProject(projDto);
        Console.WriteLine("Project added successfully.");
    }

    static void UpdateBug(BugService bugService)
    {
        Console.Write("Enter Bug Id to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        var existingBug = bugService.GetBugById(id);
        if (existingBug == null)
        {
            Console.WriteLine("Bug not found.");
            return;
        }

        Console.Write("Enter new Title (leave blank to keep current): ");
        var title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title))
            existingBug.Title = title;

        Console.Write("Enter new Description (leave blank to keep current): ");
        var description = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(description))
            existingBug.Description = description;

        Console.Write("Enter new Project Id (leave blank to keep current): ");
        var projectIdStr = Console.ReadLine();
        if (int.TryParse(projectIdStr, out int projectId))
            existingBug.ProjectId = projectId;

        Console.Write("Enter new Due Date (yyyy-MM-dd) or leave blank to keep current: ");
        var dueDateStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(dueDateStr))
        {
            if (DateTime.TryParse(dueDateStr, out var dueDate))
                existingBug.DueDate = dueDate;
            else
            {
                Console.WriteLine("Invalid date format. Update canceled.");
                return;
            }
        }

        bugService.UpdateBug(existingBug);
        Console.WriteLine("Bug updated successfully.");
    }

    static void UpdateProject(ProjectService projectService)
    {
        Console.Write("Enter Project Id to update: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        var existingProject = projectService.GetProjectById(id);
        if (existingProject == null)
        {
            Console.WriteLine("Project not found.");
            return;
        }

        Console.Write("Enter new Name (leave blank to keep current): ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            existingProject.Name = name;

        Console.Write("Enter new Description (leave blank to keep current): ");
        var description = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(description))
            existingProject.Description = description;

        projectService.UpdateProject(existingProject);
        Console.WriteLine("Project updated successfully.");
    }

    static void DeleteBug(BugService bugService)
    {
        Console.Write("Enter Bug Id to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        bugService.DeleteBug(id);
        Console.WriteLine("Bug deleted successfully.");
    }

    static void DeleteProject(ProjectService projectService)
    {
        Console.Write("Enter Project Id to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid Id.");
            return;
        }

        projectService.DeleteProject(id);
        Console.WriteLine("Project deleted successfully.");
    }
}
