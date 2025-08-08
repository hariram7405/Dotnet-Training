using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;

namespace BugTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new()
        {
            new Project { Id = 1, Name = "Alpha" },
            new Project { Id = 2, Name = "Beta" },
            new Project { Id = 3, Name = "Gamma" }
        };

        public Project? GetById(int id)
        {
            return _projects.FirstOrDefault(p => p.Id == id);
        }
    }
}
