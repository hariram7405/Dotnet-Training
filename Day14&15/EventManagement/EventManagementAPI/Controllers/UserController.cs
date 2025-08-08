using EventManagement.Core.DTOs;
using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserResponseDto>> GetAll()
    {
        var users = _userService.GetAllUsers()
                     .Select(u => new UserResponseDto
                     {
                         Id = u.Id,
                         Name = u.Name,
                         Email = u.Email
                     });
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponseDto> GetById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound();

        return Ok(new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        });
    }
}
