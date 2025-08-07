using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;


namespace BugTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new();
        private static int st = 0;
        public void Add(Project entity)
        {
            st++;
            entity.Id = st;
            _projects.Add(entity);
        }

        public void Update(Project entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Description = entity.Description;
                existing.StartDate = entity.StartDate;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null) _projects.Remove(existing);
        }

        public Project? GetById(int id) => _projects.FirstOrDefault(p => p.Id == id);

        public List<Project> GetAll() => new List<Project>(_projects);
    }
}
