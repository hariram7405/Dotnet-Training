using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using System.Collections.Generic;

namespace EventManagement.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void CreateEvent(Event eventObj)
        {
            _eventRepository.Add(eventObj);
        }

        public Event? GetEventById(int id)
        {
            return _eventRepository.GetById(id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAll();
        }
    }
}
