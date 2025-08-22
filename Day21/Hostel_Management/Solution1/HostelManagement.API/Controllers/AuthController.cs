using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HostelManagement.Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace HostelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            // Input validation
            if (request == null)
                return BadRequest("Request body is required");

            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Username and password are required");

            // Validate credentials (hardcoded for demo - replace with database validation)
            if (!IsValidUser(request.UserName, request.Password))
                return Unauthorized(new { message = "Invalid username or password" });

            try
            {
                var token = GenerateJwtToken(request.UserName);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error generating token", details = ex.Message });
            }
        }

        [HttpPost("refresh")]
        [Authorize]
        public IActionResult RefreshToken()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
                return Unauthorized("Invalid token");

            try
            {
                var newToken = GenerateJwtToken(username);
                return Ok(newToken);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error refreshing token", details = ex.Message });
            }
        }

        [HttpPost("validate")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            var username = User.Identity?.Name;
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            
            return Ok(new 
            { 
                isValid = true, 
                username = username,
                claims = claims
            });
        }

        private bool IsValidUser(string username, string password)
        {
            // Demo credentials - replace with actual user validation logic
            var validUsers = new Dictionary<string, string>
            {
                { "admin", "password" },
                { "warden", "warden123" },
                { "staff", "staff123" }
            };

            return validUsers.ContainsKey(username.ToLower()) && 
                   validUsers[username.ToLower()] == password;
        }

        private AuthResponse GenerateJwtToken(string username)
        {
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
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, 
                    new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), 
                    ClaimValueTypes.Integer64)
            };

            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                Token = tokenString,
                Expiration = expiration
            };
        }
    }
}
