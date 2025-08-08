
using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.DTOs;
[ApiController]
[Route("api/[controller]")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;
    private readonly IUserService _userService;
    private readonly IEventService _eventService;

    public RegistrationsController(IRegistrationService registrationService,
                                   IUserService userService,
                                   IEventService eventService)
    {
        _registrationService = registrationService;
        _userService = userService;
        _eventService = eventService;
    }

    [HttpGet("event/{eventId}")]
    public ActionResult<IEnumerable<RegistrationResponseDto>> GetByEventId(int eventId)
    {
        var registrations = _registrationService.GetRegistrationsByEventId(eventId);
        var result = new List<RegistrationResponseDto>();

        foreach (var reg in registrations)
        {
            var user = _userService.GetUserById(reg.UserId);
            var evt = _eventService.GetEventById(reg.EventId);

            result.Add(new RegistrationResponseDto
            {
                Id = reg.Id,
                UserId = reg.UserId,
                UserName = user?.Name ?? "Unknown",
                EventId = reg.EventId,
                EventTitle = evt?.Title ?? "Unknown",
                RegistrationDate = reg.RegistrationDate
            });
        }

        return Ok(result);
    }
}
