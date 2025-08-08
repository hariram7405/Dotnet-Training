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
    public ActionResult<IEnumerable<EventResponseDto>> GetAll()
    {
        var events = _eventService.GetAllEvents()
                      .Select(e => new EventResponseDto
                      {
                          Id = e.Id,
                          Title = e.Title,
                          Description = e.Description,
                          Date = e.Date,
                          Location = e.Location
                      });
        if (events == null) return NotFound();

        return Ok(events);
    }

    [HttpGet("{id}")]
    public ActionResult<EventResponseDto> GetById(int id)
    {
        var evt = _eventService.GetEventById(id);
        if (evt == null) return NotFound();

        return Ok(new EventResponseDto
        {
            Id = evt.Id,
            Title = evt.Title,
            Description = evt.Description,
            Date = evt.Date,
            Location = evt.Location
        });
    }
}
