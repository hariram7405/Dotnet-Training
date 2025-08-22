using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using EventManagement.Core.Exceptions;
using EventManagement.Core.DTOs;

namespace EventManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUserAsync(UserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("User name is required");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ValidationException("User email is required");

            // Check for duplicate email
            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Email.ToLower() == request.Email.ToLower());
            if (existingUser != null)
                throw new DuplicateUserException($"User with email '{request.Email}' already exists");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email
            };
                
            _userRepository.Add(user);
            return await Task.FromResult(user.Id);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            
            var user = _userRepository.GetById(id);
            if (user == null) throw new NotFoundException($"User with ID {id} not found");
            
            return await Task.FromResult(MapToResponseDTO(user));
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = _userRepository.GetAll();
            return await Task.FromResult(users.Select(MapToResponseDTO));
        }

        public async Task UpdateUserAsync(int id, UserRequest request)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("User name is required");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ValidationException("User email is required");
                
            var existing = _userRepository.GetById(id);
            if (existing == null) throw new NotFoundException($"User with ID {id} not found");
            
            existing.Name = request.Name;
            existing.Email = request.Email;
            
            _userRepository.Update(existing);
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            
            var existing = _userRepository.GetById(id);
            if (existing == null) throw new NotFoundException($"User with ID {id} not found");
            
            _userRepository.Delete(id);
            await Task.CompletedTask;
        }

        // Legacy methods for MVC compatibility
        public User? GetUserById(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        private UserResponseDto MapToResponseDTO(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
