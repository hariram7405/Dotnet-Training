using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = new List<Bug>();
        private int _nextId = 1;

        public void Add(Bug entity)
        {
            entity.Id = _nextId++;
            entity.CreatedDate = DateTime.Now;
            _bugs.Add(entity);
        }

        public void Delete(int id)
        {
            var bug = GetById(id);
            if (bug != null) _bugs.Remove(bug);
        }

        public List<Bug> GetAll() => _bugs;

        public Bug GetById(int id) => _bugs.FirstOrDefault(b => b.Id == id);

        public void Update(Bug entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Title = entity.Title;
                existing.Description = entity.Description;
                existing.Priority = entity.Priority;
                existing.CreatedBy = entity.CreatedBy;
                existing.Project = entity.Project;
            }
        }

        public IEnumerable<Bug> GetBugsByPriority(string priority) =>
            _bugs.Where(b => b.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase));
    }
}
