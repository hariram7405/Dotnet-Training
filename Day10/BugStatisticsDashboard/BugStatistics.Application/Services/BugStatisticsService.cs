using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugStatistics.Core.Interface;

namespace BugStatistics.Application.Services
{
   public class BugStatisticsService
    {
       

        private readonly IBugRepository _repo;

        public BugStatisticsService(IBugRepository repo)
        {
            _repo = repo;
        }

        public void ShowBugCountByStatus()
        {
            var bugs = _repo.GetBugs();

            var grouped = bugs
                .GroupBy(b => b.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() });

            Console.WriteLine("Bug Count by Status:");
            foreach (var item in grouped)
            {
                Console.WriteLine($"Status: {item.Status}, Count: {item.Count}");
            }
        }

        public void ShowBugCountByProjectAndPriortiy()
        {
            var bugs = _repo.GetBugs();

            var grouped = bugs
                .GroupBy(b => new { b.ProjectName, b.Priority })
                .Select(g => new
                {
                    Project = g.Key.ProjectName,
                    Priority = g.Key.Priority,
                    Count = g.Count()
                });

            Console.WriteLine("Bug Count by Project and Priority:");
            foreach (var item in grouped)
            {
                Console.WriteLine($"Project: {item.Project}, Priority: {item.Priority}, Count: {item.Count}");
            }
        }

        public void ShowDailyBug()
        {
            var bugs = _repo.GetBugs();

            var dailyGroups = bugs
                .GroupBy(b => b.CreatedOn.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .OrderBy(x => x.Date);

            Console.WriteLine("Daily Bug Count:");
            foreach (var day in dailyGroups)
            {
                Console.WriteLine($"{day.Date:yyyy-MM-dd}: {day.Count} bugs");
            }
        }

        public void ShowTopCreators()
        {
            var bugs = _repo.GetBugs();

            var topCreators = bugs
                .GroupBy(b => b.CreatedBy)
                .Select(g => new { Creator = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(3);

            Console.WriteLine("Top 3 Bug Creators:");
            foreach (var creator in topCreators)
            {
                Console.WriteLine($"{creator.Creator}: {creator.Count} bugs");
            }
        }

    }
}
