using EventManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Interfaces
{
public  interface IEventService
    {
        void CreateEvent(Event entity);
        Event? GetEventById(int id);
        IEnumerable<Event> GetAllEvents();
    }
}
