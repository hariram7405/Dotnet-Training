using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BugStatistics.Core.Entities;
using BugStatistics.Core.Interface; 

namespace BugStatistics.Infrastructure.Repositories
    {
        public class BugRepository:IBugRepository
        {
            private readonly List<Bug> _bugs;

            public BugRepository()
            {
                _bugs = new List<Bug>
            {
                new Bug
                {
                    Id = 1,
                    Title = "NullReferenceException in Login",
                    Priority = "High",
                    ProjectName = "AuthSystem",
                    Status = "Open",
                    CreatedBy = "Alice",
                    CreatedOn = DateTime.Now.AddDays(-7)
                },
                new Bug
                {
                    Id = 2,
                    Title = "UI glitch on dashboard",
                    Priority = "Medium",
                    ProjectName = "Dashboard",
                    Status = "In Progress",
                    CreatedBy = "Bob",
                    CreatedOn = DateTime.Now.AddDays(-5)
                },
                new Bug
                {
                    Id = 3,
                    Title = "Slow response in API",
                    Priority = "High",
                    ProjectName = "BackendService",
                    Status = "Open",
                    CreatedBy = "Charlie",
                    CreatedOn = DateTime.Now.AddDays(-10)
                },
                new Bug
                {
                    Id = 4,
                    Title = "Typo in user settings",
                    Priority = "Low",
                    ProjectName = "Frontend",
                    Status = "Closed",
                    CreatedBy = "Dana",
                    CreatedOn = DateTime.Now.AddDays(-3)
                },
                new Bug
                {
                    Id = 5,
                    Title = "Crash on logout",
                    Priority = "Critical",
                    ProjectName = "AuthSystem",
                    Status = "Open",
                    CreatedBy = "Eve",
                    CreatedOn = DateTime.Now.AddDays(-1)
                }
            };
            }

            public IReadOnlyList<Bug> GetBugs()
            {
                return _bugs.AsReadOnly();
            }
        }
    }



