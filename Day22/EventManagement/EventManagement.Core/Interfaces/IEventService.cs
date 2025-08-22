using EventManagement.Core.Entities;
using EventManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Interfaces
{
    public interface IEventService
    {
        Task<int> CreateEventAsync(EventRequestDTO request);
        Task<EventResponseDto> GetEventByIdAsync(int id);
        Task<IEnumerable<EventResponseDto>> GetAllEventsAsync();
        Task UpdateEventAsync(int id, EventRequestDTO request);
        Task DeleteEventAsync(int id);
    }
}
