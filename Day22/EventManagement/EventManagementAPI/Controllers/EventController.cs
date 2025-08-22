using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.DTOs;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetAll()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventResponseDto>> GetById(int id)
    {
        var evt = await _eventService.GetEventByIdAsync(id);
        return Ok(evt);
    }

    [HttpPost]
    public async Task<ActionResult> Create(EventRequestDTO request)
    {
        var eventId = await _eventService.CreateEventAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = eventId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EventRequestDTO request)
    {
        await _eventService.UpdateEventAsync(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _eventService.DeleteEventAsync(id);
        return NoContent();
    }
}
