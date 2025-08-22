using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreDTOs = BugTracker.Core.DTOs;

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

        [HttpPost("register")]
        public IActionResult Register([FromBody] CoreDTOs.RegisterRequest request)
        {
            if (_users.Any(u => u.Username.ToLower() == request.Username.ToLower()))
            {
                return BadRequest("Username already exists");
            }

            var user = new User
            {
                Username = request.Username
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            _users.Add(user);

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] CoreDTOs.LoginRequest request)
        {
            var user = _users.FirstOrDefault(u => u.Username.ToLower() == request.UserName.ToLower());

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return Unauthorized("Invalid credentials");
            }

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
                new Claim(ClaimTypes.Name, request.UserName),
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

            return Ok(new AuthResponse
            {
                Token = tokenString,
                Expiration = expiration
            });
        }
    }
}
