using System;
using System.Collections.Generic;
using System.Linq;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Infrastructure.Repositories
{
    public class RegistrationRepository : IRepository<Registration>
    {
        private readonly List<Registration> _registrations = new List<Registration>();

        public RegistrationRepository()
        {
            _registrations = new List<Registration>
    {
        new Registration
        {
            Id = 1,
            UserId = 1,  
            EventId = 1,
            RegistrationDate = DateTime.Now
        },
        new Registration
        {
            Id = 2,
            UserId = 2, 
            EventId = 1,
            RegistrationDate = DateTime.Now
        },
        new Registration
        {
            Id = 3,
            UserId = 3, 
            EventId = 2,
            RegistrationDate = DateTime.Now
        },
        new Registration
        {
            Id = 4,
            UserId = 4,  
            EventId = 3,
            RegistrationDate = DateTime.Now
        },
        new Registration
        {
            Id = 5,
            UserId = 1,  
            EventId = 2,
            RegistrationDate = DateTime.Now
        }
    };
        }

        public void Add(Registration entity)
        {
            _registrations.Add(entity);
        }

        public void Update(Registration entity)
        {
            var existing = _registrations.FirstOrDefault(r => r.Id == entity.Id);
            if (existing != null)
            {
                existing.UserId = entity.UserId;
                existing.EventId = entity.EventId;
                existing.RegistrationDate = entity.RegistrationDate;
            }
        }

        public void Delete(int id)
        {
            var existing = _registrations.FirstOrDefault(r => r.Id == id);
            if (existing != null)
            {
                _registrations.Remove(existing);
            }
        }

        public Registration? GetById(int id)
        {
            return _registrations.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Registration> GetAll()
        {
            return _registrations;
        }

        
    }
}
