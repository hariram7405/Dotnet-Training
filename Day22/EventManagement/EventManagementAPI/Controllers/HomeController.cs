using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.Interfaces;
using EventManagement.Core.DTOs;

namespace EventManagementAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index(string searchTitle = "", string searchLocation = "")
        {
            var events = await _eventService.GetAllEventsAsync();
            
            if (!string.IsNullOrEmpty(searchTitle))
                events = events.Where(e => e.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase));
            
            if (!string.IsNullOrEmpty(searchLocation))
                events = events.Where(e => e.Location.Contains(searchLocation, StringComparison.OrdinalIgnoreCase));

            var eventDtos = events.Select(e => new EventResponseDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Location = e.Location
            });

            ViewBag.SearchTitle = searchTitle;
            ViewBag.SearchLocation = searchLocation;
            
            return View(eventDtos);
        }
    }
}