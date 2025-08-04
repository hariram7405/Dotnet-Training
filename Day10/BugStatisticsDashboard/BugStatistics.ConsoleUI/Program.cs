using System;
using BugStatistics.Application.Services;
using BugStatistics.Infrastructure.Repositories;

class Program
{
    static void Main()
    {
        var repo = new BugRepository(); 
        var service = new BugStatisticsService(repo);

        while (true)
        {
            Console.WriteLine("\n-- BugDashboard Menu --");
            Console.WriteLine("1. Bug Count by Status");
            Console.WriteLine("2. Bug Count by Project and Priority");
            Console.WriteLine("3. Daily Bug Report");
            Console.WriteLine("4. Top Bug Creators");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    service.ShowBugCountByStatus();
                    break;
                case "2":
                    service.ShowBugCountByProjectAndPriortiy();
                    break;
                case "3":
                    service.ShowDailyBug();
                    break;
                case "4":
                    service.ShowTopCreators();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

  
}