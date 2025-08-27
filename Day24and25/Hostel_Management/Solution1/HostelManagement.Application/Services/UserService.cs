using HostelManagement.Core.DTOs;
using HostelManagement.Core.Entities;
using HostelManagement.Core.Interfaces;
using HostelManagement.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HostelManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Staff> _staffRepo;
        private readonly IConfiguration _configuration;

        public UserService(IRepository<User> userRepo, IRepository<Staff> staffRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _staffRepo = staffRepo;
            _configuration = configuration;
        }

        
        private string HashPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[16];
            rng.GetBytes(salt);

        
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

           
            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        //  Verify password
        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] stored = Convert.FromBase64String(parts[1]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(stored, hash);
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepo.ExistsByUsernameAsync(request.Username))
                throw new ValidationException("Username already exists");

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password), 
                Role = request.Role
            };

            await _userRepo.AddAsync(user);

            if (user.Role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
            {
                var staff = new Staff
                {
                    Name = user.Username,
                    Role = "Staff"
                };
                await _staffRepo.AddAsync(staff);
            }

            return new RegisterResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var user = await _userRepo.GetByUsernameAsync(request.Username);

            if (user == null || !VerifyPassword(request.Password, user.PasswordHash)) // ✅ verify PBKDF2
                throw new ValidationException("Invalid credentials");

            return GenerateJwtToken(user);
        }

        private AuthResponse GenerateJwtToken(User user)
        {
            var jwtConfig = _configuration.GetSection("JWT");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"] ?? ""));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var expiration = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
