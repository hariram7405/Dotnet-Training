using System;
using BugTracker.Core.Entities;
using BugTracker.Application.Services;
using BugTracker.Infrastructure.Repositories;

namespace BugTracker.ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var userService = new UserService(new UserRepository());
            var projectService = new ProjectService(new ProjectRepository());
            var bugService = new BugService(new BugRepository());

            while (true)
            {
                Console.WriteLine("\n--- Bug Tracker Menu ---");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Project");
                Console.WriteLine("3. Add Bug");
                Console.WriteLine("4. View All Bugs");
                Console.WriteLine("5. View High Priority Bugs");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter user name: ");
                        var userName = Console.ReadLine();
                        userService.CreateUser(new User { Name = userName });
                        Console.WriteLine("User created.");
                        break;

                    case "2":
                        Console.Write("Enter project name: ");
                        var projectName = Console.ReadLine();
                        projectService.CreateProject(new Project { Name = projectName });
                        Console.WriteLine("Project created.");
                        break;

                    case "3":
                        var users = userService.GetAllUsers();
                        var projects = projectService.GetAllProjects();

                        if (users.Count == 0 || projects.Count == 0)
                        {
                            Console.WriteLine("You must create at least one user and one project first.");
                            break;
                        }

                        Console.Write("Enter bug title: ");
                        var title = Console.ReadLine();

                        Console.Write("Enter description: ");
                        var description = Console.ReadLine();

                        Console.Write("Enter priority (Low/Medium/High): ");
                        var priority = Console.ReadLine();

                        Console.WriteLine("Select User:");
                        for (int i = 0; i < users.Count; i++)
                            Console.WriteLine($"{i + 1}. {users[i].Name}");
                        int userIndex = int.Parse(Console.ReadLine()) - 1;

                        Console.WriteLine("Select Project:");
                        for (int i = 0; i < projects.Count; i++)
                            Console.WriteLine($"{i + 1}. {projects[i].Name}");
                        int projectIndex = int.Parse(Console.ReadLine()) - 1;

                        var bug = new Bug
                        {
                            Title = title,
                            Description = description,
                            Priority = priority,
                            CreatedBy = users[userIndex],
                            Project = projects[projectIndex]
                        };

                        bugService.CreateBug(bug);
                        Console.WriteLine("Bug created.");
                        break;

                    case "4":
                        var allBugs = bugService.GetAllBugs();
                        foreach (var b in allBugs)
                        {
                            Console.WriteLine($"ID: {b.Id} | Title: {b.Title} | Priority: {b.Priority} | By: {b.CreatedBy.Name} | Project: {b.Project.Name}");
                        }
                        break;

                    case "5":
                        var highBugs = bugService.GetHighPriorityBugs();
                        foreach (var b in highBugs)
                        {
                            Console.WriteLine($"ID: {b.Id} | Title: {b.Title} | Priority: {b.Priority} | By: {b.CreatedBy.Name} | Project: {b.Project.Name}");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
