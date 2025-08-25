using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private static List<User> _users = new();
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // REGISTER USER
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_users.Any(u => u.Username.ToLower() == request.Username.ToLower()))
            {
                return BadRequest(new
                {
                    Message = "Username already exists",
                    Role = request.Role
                });
            }

            var passwordHash = _passwordHasher.HashPassword(null, request.Password);

            var user = new User
            {
                Username = request.Username,
                Role = request.Role,
                PasswordHash = passwordHash
            };

            _users.Add(user);

            return Ok(new
            {
                Message = "User registered successfully",
                Role = user.Role
            });
        }

        // LOGIN USER
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _users.FirstOrDefault(u => u.Username.ToLower() == request.UserName.ToLower());

            if (user == null)
                return Unauthorized("Invalid credentials");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result != PasswordVerificationResult.Success)
                return Unauthorized("Invalid credentials");

            var jwtConfig = _configuration.GetSection("JWT");
            var key = jwtConfig["Key"];
            var issuer = jwtConfig["Issuer"];
            var audience = jwtConfig["Audience"];

            if (string.IsNullOrWhiteSpace(key))
                throw new InvalidOperationException("JWT Key is missing from configuration");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                Token = tokenString,
                Expiration = expiration,
                Role = user.Role
            });
        }
    }
}
