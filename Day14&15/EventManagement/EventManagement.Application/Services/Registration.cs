using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRepository<Registration> _registrationRepository;

        public RegistrationService(IRepository<Registration> registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public void RegisterUserForEvent(Registration registration)
        {
            _registrationRepository.Add(registration);
        }

        public IEnumerable<Registration> GetRegistrationsByEventId(int eventId)
        {
            return _registrationRepository
                   .GetAll()
                   .Where(r => r.EventId == eventId);
        }

        public IEnumerable<Registration> GetAllRegistrations()
        {
            return _registrationRepository.GetAll();
        }
    }
}
