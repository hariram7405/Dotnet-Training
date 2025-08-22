using Microsoft.AspNetCore.Mvc;
using EventManagement.MVC.Models;
using System.Text.Json;

namespace EventManagement.MVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7282/api";

        public EventsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(string searchTerm, string location)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/events");
                var events = JsonSerializer.Deserialize<List<EventViewModel>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<EventViewModel>();
                
                // Apply filtering
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    events = events.Where(e => e.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
                                              e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                
                if (!string.IsNullOrEmpty(location))
                {
                    events = events.Where(e => e.Location.Contains(location, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                
                ViewBag.SearchTerm = searchTerm;
                ViewBag.Location = location;
                return View(events);
            }
            catch
            {
                var events = new List<EventViewModel>
                {
                    new EventViewModel { Id = 1, Title = "ASP.NET Core Workshop", Description = "Backend development with .NET", Date = new DateTime(2025, 8, 30, 10, 0, 0), Location = "Chennai" }
                };
                return View(events);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var eventResponse = await _httpClient.GetStringAsync($"{_apiBaseUrl}/events/{id}");
                var eventItem = JsonSerializer.Deserialize<EventViewModel>(eventResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                var registrationsResponse = await _httpClient.GetStringAsync($"{_apiBaseUrl}/registrations/event/{id}");
                var registrations = JsonSerializer.Deserialize<List<RegistrationApiResponse>>(registrationsResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                var registrationViewModels = registrations?.Select(r => new RegistartionViewModel
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    UserName = r.UserName ?? $"User {r.UserId}",
                    EventId = r.EventId,
                    RegistrationDate = r.RegistrationDate
                }).ToList() ?? new List<RegistartionViewModel>();

                ViewBag.Event = eventItem;
                return View(registrationViewModels);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
