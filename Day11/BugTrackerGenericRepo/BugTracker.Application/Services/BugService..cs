using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;

namespace BugTracker.Application.Services
{
    public class BugService
    {
        private readonly IBugRepository _bugRepository;

        public BugService(IBugRepository bugRepository)
        {
            _bugRepository = bugRepository;
        }

        public void CreateBug(Bug bug) => _bugRepository.Add(bug);

        public IEnumerable<Bug> GetAllBugs() => _bugRepository.GetAll();

        public IEnumerable<Bug> GetHighPriorityBugs() => _bugRepository.GetBugsByPriority("High");
    }
}
