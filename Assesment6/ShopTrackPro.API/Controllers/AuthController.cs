using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.DTOs.Auth;
using ShopTrackPro.Core.DTOs.User;
using ShopTrackPro.Core.DTOs;

namespace ShopTrackPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<TokenDto>>> Login(LoginDto loginDto)
    {
        var token = await authService.LoginAsync(loginDto);
        return Ok(new ApiResponse<TokenDto>
        {
            Message = "Login successful",
            Data = token
        });
    }

    [HttpPost("register")]
    public async Task<ActionResult<ApiResponse<UserDto>>> Register(RegisterDto registerDto)
    {
        var user = await authService.RegisterAsync(registerDto);
        return CreatedAtAction(nameof(Register), new ApiResponse<UserDto>
        {
            Message = "User registered successfully",
            Data = user
        });
    }
}