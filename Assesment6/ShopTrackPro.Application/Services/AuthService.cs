using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.DTOs.Auth;
using ShopTrackPro.Core.DTOs.User;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Exceptions;

namespace ShopTrackPro.Application.Services;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    private const string SecretKey = "YourSuperSecretKeyThatIsAtLeast32CharactersLong!";
    private readonly PasswordHasher<object> _passwordHasher = new();

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        var user = await userRepository.GetByUsernameAsync(loginDto.Username);
        if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            throw new UnauthorizedException("Invalid username or password");

        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role
        };

        var token = GenerateJwtToken(userDto);
        return new TokenDto
        {
            Token = token,
            Expires = DateTime.UtcNow.AddHours(24),
            Role = user.Role,
            Username = user.Username
        };
    }

    public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
    {
        if (await userRepository.UsernameExistsAsync(registerDto.Username))
            throw new DuplicateEmailException("Username already exists");

        if (await userRepository.EmailExistsAsync(registerDto.Email))
            throw new DuplicateEmailException("Email already exists");

        var user = new User
        {
            Username = registerDto.Username,
            Email = registerDto.Email,
            Role = registerDto.Role,
            PasswordHash = HashPassword(registerDto.Password)
        };

        var created = await userRepository.AddAsync(user);
        return new UserDto
        {
            Id = created.Id,
            Username = created.Username,
            Email = created.Email,
            Role = created.Role
        };
    }

    public Task<bool> ValidateTokenAsync(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public string GenerateJwtToken(UserDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    private bool VerifyPassword(string password, string hash)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hash, password);
        return result == PasswordVerificationResult.Success;
    }
}