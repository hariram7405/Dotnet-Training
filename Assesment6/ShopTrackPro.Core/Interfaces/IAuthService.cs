using ShopTrackPro.Core.DTOs.Auth;
using ShopTrackPro.Core.DTOs.User;

namespace ShopTrackPro.Core.Interfaces;

public interface IAuthService
{
    Task<TokenDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> RegisterAsync(RegisterDto registerDto);
    Task<bool> ValidateTokenAsync(string token);
    string GenerateJwtToken(UserDto user);
}