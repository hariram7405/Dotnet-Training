using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BugTracker.Infrastructure.Repositories
{
    public class BugRepository : IBugRepository
    {
        private readonly List<Bug> _bugs = new();
        private static int st = 0;//id auto generated
        public void Add(Bug entity)
        {
            st++;
            entity.Id = st;
            entity.CreatedOn = DateTime.Now;
            _bugs.Add(entity);
        }

        public void Update(Bug entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Title = entity.Title;
                existing.Description = entity.Description;
                existing.Status = entity.Status;
                existing.DueDate = entity.DueDate;
                existing.ProjectId = entity.ProjectId;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null) _bugs.Remove(existing);
        }

        public Bug? GetById(int id) => _bugs.FirstOrDefault(b => b.Id == id);

        public List<Bug> GetAll() => new List<Bug>(_bugs);
    }
}
