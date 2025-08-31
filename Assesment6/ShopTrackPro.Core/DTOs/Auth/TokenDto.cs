namespace ShopTrackPro.Core.DTOs.Auth;

public class TokenDto
{
    public required string Token { get; set; }
    public DateTime Expires { get; set; }
    public required string Role { get; set; }
    public required string Username { get; set; }
}