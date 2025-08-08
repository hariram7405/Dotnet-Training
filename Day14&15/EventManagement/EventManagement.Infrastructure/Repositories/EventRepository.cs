using System;
using System.Collections.Generic;
using System.Linq;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Infrastructure.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly List<Event> _events = new();

        public EventRepository()
        {
            _events = new List<Event>
    {
        new Event
        {
            Id = 1,
            Title = "ASP.NET Core Workshop",
            Description = "Backend development with .NET",
            Date = new DateTime(2025, 08, 30, 10, 0, 0),
            Location = "Chennai"
        },
        new Event
        {
            Id = 2,
            Title = "Cloud DevOps Bootcamp",
            Description = "CI/CD and DevOps on Azure",
            Date = new DateTime(2025, 09, 05, 14, 0, 0),
            Location = "Bangalore"
        },
        new Event
        {
            Id = 3,
            Title = "Blazor WebAssembly Crash Course",
            Description = "Full-stack C# with Blazor",
            Date = new DateTime(2025, 09, 10, 9, 0, 0),
            Location = "Hyderabad"
        }
    };
        }


        public void Add(Event entity)
        {
            _events.Add(entity);
        }

        public void Update(Event entity)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == entity.Id);
            if (existingEvent != null)
            {
                existingEvent.Title = entity.Title;
                existingEvent.Description = entity.Description;
                existingEvent.Date = entity.Date;
                existingEvent.Location = entity.Location;
            }
        }

        public void Delete(int id)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == id);
            if (existingEvent != null)
            {
                _events.Remove(existingEvent);
            }
        }

        public Event? GetById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _events;
        }
    }
}
