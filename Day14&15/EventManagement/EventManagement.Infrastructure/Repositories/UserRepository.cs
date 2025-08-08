using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Infrastructure.Repositories
{
   public class UserRepository:IRepository<User>
    {
        private readonly List<User>_users=new List<User>();
        public UserRepository()
        {
            _users = new List<User>
    {
        new User { Id = 1, Name = "Haripriya", Email = "haripriya@example.com" },
        new User { Id = 2, Name = "Ram", Email = "ram@example.com" },
        new User { Id = 3, Name = "Shiva", Email = "shiva@example.com" },
        new User { Id = 4, Name = "Kavi", Email = "kavi@example.com" }
    };
        }

        public void Add(User entity)
        {
            _users.Add(entity);
        }
        public void Update(User entity) {
            var existingUsers = _users.FirstOrDefault(b => b.Id == entity.Id);
            if (existingUsers != null)
            {
                existingUsers.Id = entity.Id;
                existingUsers.Name = entity.Name;
                existingUsers.Email = entity.Email;
            }
              
        }
       public  void Delete(int id) {
            var user = GetById(id);
            if (user!= null)
            {
                _users.Remove(user);
            }

        }
      public   User? GetById(int id)
        {
            return _users.FirstOrDefault(b => b.Id == id);
        }
      public   IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
