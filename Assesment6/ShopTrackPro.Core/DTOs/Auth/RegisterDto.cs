namespace ShopTrackPro.Core.DTOs.Auth;

public class RegisterDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string Role { get; set; } = "Customer";
}