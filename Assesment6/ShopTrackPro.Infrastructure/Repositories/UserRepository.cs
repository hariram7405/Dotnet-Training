using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Core.Interfaces;
using CoreEntities = ShopTrackPro.Core.Entities;
using ShopTrackPro.Infrastructure.Data;

namespace ShopTrackPro.Infrastructure.Repositories;

public class UserRepository(ShopTrackProContext context) : Repository<CoreEntities.User>(context), IUserRepository
{
    public async Task<CoreEntities.User?> GetByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        return user is null ? null : new CoreEntities.User
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            PasswordHash = user.PasswordHash
        };
    }

    public async Task<CoreEntities.User?> GetByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user is null ? null : new CoreEntities.User
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            PasswordHash = user.PasswordHash
        };
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}