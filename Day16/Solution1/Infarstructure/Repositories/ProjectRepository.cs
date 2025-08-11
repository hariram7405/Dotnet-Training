using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new();
      

        private int _nextId = 1;

        public void Add(Project project)
        {
            project.Id = _nextId++;
            _projects.Add(project);
        }

        public Project GetById(int id)
        {
            return _projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _projects;
        }
    }
}
