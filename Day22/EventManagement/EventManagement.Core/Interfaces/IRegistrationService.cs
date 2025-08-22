using EventManagement.Core.Entities;
using EventManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Interfaces
{
    public interface IRegistrationService
    {
        Task<RegistrationResponseDto> RegisterUserForEventAsync(RegistrationRequest request);
        Task<IEnumerable<RegistrationResponseDto>> GetRegistrationsByEventIdAsync(int eventId);
        Task<IEnumerable<RegistrationResponseDto>> GetRegistrationsByUserIdAsync(int userId);
        Task<IEnumerable<RegistrationResponseDto>> GetAllRegistrationsAsync();
        Task DeleteRegistrationAsync(int registrationId);
    }
}
