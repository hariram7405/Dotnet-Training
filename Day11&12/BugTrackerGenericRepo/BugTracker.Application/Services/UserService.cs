using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using System.Collections.Generic;

namespace BugTracker.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user) => _userRepository.Add(user);

        public List<User> GetAllUsers() => _userRepository.GetAll();
    }
}
