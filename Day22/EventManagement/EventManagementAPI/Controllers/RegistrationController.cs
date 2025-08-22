using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.DTOs;
using EventManagement.Core.Entities;

[ApiController]
[Route("api/[controller]")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationsController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpGet("event/{eventId}")]
    public async Task<ActionResult<IEnumerable<RegistrationResponseDto>>> GetByEventId(int eventId)
    {
        var registrations = await _registrationService.GetRegistrationsByEventIdAsync(eventId);
        return Ok(registrations);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegistrationResponseDto>>> GetAll()
    {
        var registrations = await _registrationService.GetAllRegistrationsAsync();
        return Ok(registrations);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<RegistrationResponseDto>>> GetByUserId(int userId)
    {
        var registrations = await _registrationService.GetRegistrationsByUserIdAsync(userId);
        return Ok(registrations);
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegistrationRequest request)
    {
        var response = await _registrationService.RegisterUserForEventAsync(request);
        return CreatedAtAction(nameof(GetByEventId), new { eventId = request.EventId }, response);
    }

    [HttpDelete("{registrationId}")]
    public async Task<IActionResult> Delete(int registrationId)
    {
        await _registrationService.DeleteRegistrationAsync(registrationId);
        return NoContent();
    }
}

