using EventManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Interfaces
{
 public  interface IUserService
    {
        void CreateUser(User entity);
        User? GetUserById(int id);
        IEnumerable<User> GetAllUsers();
    }
}
