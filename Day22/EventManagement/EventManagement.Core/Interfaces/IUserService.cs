using EventManagement.Core.Entities;
using EventManagement.Core.DTOs;

namespace EventManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserRequest request);
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task UpdateUserAsync(int id, UserRequest request);
        Task DeleteUserAsync(int id);
        // Legacy methods for MVC compatibility
        User? GetUserById(int id);
        IEnumerable<User> GetAllUsers();
    }
}
