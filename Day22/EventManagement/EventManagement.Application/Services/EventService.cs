using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using EventManagement.Core.Exceptions;
using EventManagement.Core.DTOs;

namespace EventManagement.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> CreateEventAsync(EventRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                throw new ValidationException("Event title is required");
            if (request.Date < DateTime.Now)
                throw new ValidationException("Event date cannot be in the past");

            // Check for duplicate event (same title and date)
            var existingEvent = _eventRepository.GetAll()
                .FirstOrDefault(e => e.Title.ToLower() == request.Title.ToLower() && e.Date.Date == request.Date.Date);
            if (existingEvent != null)
                throw new DuplicateEventException($"Event '{request.Title}' already exists on {request.Date:yyyy-MM-dd}");

            var eventObj = new Event
            {
                Title = request.Title,
                Description = request.Description,
                Date = request.Date,
                Location = request.Location
            };
                
            _eventRepository.Add(eventObj);
            return await Task.FromResult(eventObj.Id);
        }

        public async Task<EventResponseDto> GetEventByIdAsync(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid event ID");
            
            var eventItem = _eventRepository.GetById(id);
            if (eventItem == null) throw new NotFoundException($"Event with ID {id} not found");
            
            return await Task.FromResult(MapToResponseDTO(eventItem));
        }

        public async Task<IEnumerable<EventResponseDto>> GetAllEventsAsync()
        {
            var events = _eventRepository.GetAll();
            return await Task.FromResult(events.Select(MapToResponseDTO));
        }

        public async Task UpdateEventAsync(int id, EventRequestDTO request)
        {
            if (id <= 0) throw new ValidationException("Invalid event ID");
            if (string.IsNullOrWhiteSpace(request.Title))
                throw new ValidationException("Event title is required");
                
            var existing = _eventRepository.GetById(id);
            if (existing == null) throw new NotFoundException($"Event with ID {id} not found");
            
            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.Date = request.Date;
            existing.Location = request.Location;
            
            _eventRepository.Update(existing);
            await Task.CompletedTask;
        }

        public async Task DeleteEventAsync(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid event ID");
            
            var existing = _eventRepository.GetById(id);
            if (existing == null) throw new NotFoundException($"Event with ID {id} not found");
            
            _eventRepository.Delete(id);
            await Task.CompletedTask;
        }

        private EventResponseDto MapToResponseDTO(Event eventItem)
        {
            return new EventResponseDto
            {
                Id = eventItem.Id,
                Title = eventItem.Title,
                Description = eventItem.Description,
                Date = eventItem.Date,
                Location = eventItem.Location
            };
        }
    }
}
