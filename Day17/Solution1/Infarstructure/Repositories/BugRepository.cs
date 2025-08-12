using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;

namespace BugTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private static int _nextId = 1;
        private readonly List<Bug> _bugs = new();


     
        public void Add(Bug entity)
        {
            entity.Id = _nextId++;
            entity.CreatedOn = DateTime.UtcNow;
            _bugs.Add(entity);
        }

        public void Update(Bug entity)
        {
            var existing = _bugs.FirstOrDefault(b => b.Id == entity.Id);
            if (existing != null)
            {
                existing.Title = entity.Title;
                existing.Description = entity.Description;
                existing.Status = entity.Status;
                existing.ProjectId = entity.ProjectId;
            }
        }

        public void Delete(int id)
        {
            var bug = _bugs.FirstOrDefault(b => b.Id == id);
            if (bug != null)
                _bugs.Remove(bug);
        }

        public Bug? GetById(int id) => _bugs.FirstOrDefault(b => b.Id == id);

        public IEnumerable<Bug> GetAll() => _bugs;
    }
}
