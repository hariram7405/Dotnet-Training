using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new List<Project>();
        private int _nextId = 1;

        public void Add(Project entity)
        {
            entity.Id = _nextId++;
            _projects.Add(entity);
        }

        public void Delete(int id)
        {
            var project = GetById(id);
            if (project != null) _projects.Remove(project);
        }

        public List<Project> GetAll() => _projects;

        public Project GetById(int id) => _projects.FirstOrDefault(p => p.Id == id);

        public void Update(Project entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
            }
        }
    }
}
