using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using EventManagement.Core.Exceptions;
using EventManagement.Core.DTOs;

namespace EventManagement.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<Registration> _registrationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Event> _eventRepository;

        public RegistrationService(IRepository<Registration> registrationRepository, IRepository<User> userRepository, IRepository<Event> eventRepository)
        {
            _registrationRepository = registrationRepository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public void RegisterUserForEvent(Registration registration)
        {
            _registrationRepository.Add(registration);
        }

        public async Task<RegistrationResponseDto> RegisterUserForEventAsync(RegistrationRequest request)
        {
            if (request.UserId <= 0) throw new ValidationException("Invalid user ID");
            if (request.EventId <= 0) throw new ValidationException("Invalid event ID");
            
            var existing = _registrationRepository.GetAll()
                .Any(r => r.UserId == request.UserId && r.EventId == request.EventId);
            
            if (existing) throw new DuplicateRegistrationException($"User {request.UserId} is already registered for event {request.EventId}");
            
            var registration = new Registration
            {
                UserId = request.UserId,
                EventId = request.EventId,
                RegistrationDate = DateTime.Now
            };
            
            _registrationRepository.Add(registration);
            return await Task.FromResult(MapToResponseDTO(registration));
        }

        public IEnumerable<Registration> GetRegistrationsByEventId(int eventId)
        {
            return _registrationRepository
                   .GetAll()
                   .Where(r => r.EventId == eventId);
        }

        public async Task<IEnumerable<RegistrationResponseDto>> GetRegistrationsByEventIdAsync(int eventId)
        {
            if (eventId <= 0) throw new ValidationException("Invalid event ID");
            
            var registrations = _registrationRepository.GetAll().Where(r => r.EventId == eventId);
            return await Task.FromResult(registrations.Select(MapToResponseDTO));
        }

        public async Task<IEnumerable<RegistrationResponseDto>> GetAllRegistrationsAsync()
        {
            var registrations = _registrationRepository.GetAll();
            return await Task.FromResult(registrations.Select(MapToResponseDTO));
        }

        public async Task<IEnumerable<RegistrationResponseDto>> GetRegistrationsByUserIdAsync(int userId)
        {
            if (userId <= 0) throw new ValidationException("Invalid user ID");
            
            var registrations = _registrationRepository.GetAll().Where(r => r.UserId == userId);
            return await Task.FromResult(registrations.Select(MapToResponseDTO));
        }

        public async Task DeleteRegistrationAsync(int registrationId)
        {
            if (registrationId <= 0) throw new ValidationException("Invalid registration ID");
            
            var existing = _registrationRepository.GetById(registrationId);
            if (existing == null) throw new NotFoundException($"Registration with ID {registrationId} not found");
            
            _registrationRepository.Delete(registrationId);
            await Task.CompletedTask;
        }

        private RegistrationResponseDto MapToResponseDTO(Registration registration)
        {
            var user = _userRepository.GetById(registration.UserId);
            var eventItem = _eventRepository.GetById(registration.EventId);
            
            return new RegistrationResponseDto
            {
                Id = registration.Id,
                UserId = registration.UserId,
                UserName = user?.Name ?? "Unknown User",
                EventId = registration.EventId,
                EventTitle = eventItem?.Title ?? "Unknown Event",
                RegistrationDate = registration.RegistrationDate
            };
        }
    }
}
