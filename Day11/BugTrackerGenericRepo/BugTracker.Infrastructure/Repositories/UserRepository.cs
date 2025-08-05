using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();
        private int _nextId = 1;

        public void Add(User entity)
        {
            entity.Id = _nextId++;
            _users.Add(entity);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null) _users.Remove(user);
        }

        public List<User> GetAll() => _users;

        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public void Update(User entity)
        {
            var existing = GetById(entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
            }
        }
    }
}
