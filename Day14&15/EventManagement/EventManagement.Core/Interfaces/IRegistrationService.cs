using EventManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Interfaces
{
public  interface IRegistrationService
    {
        void RegisterUserForEvent(Registration registration);
        IEnumerable<Registration> GetRegistrationsByEventId(int eventId);
        IEnumerable<Registration> GetAllRegistrations();
    }
}
