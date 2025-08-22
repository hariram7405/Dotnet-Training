# 🎉 Event Management System - Complete Code Documentation

## 🚀 Project Overview

The **Event Management System** is a full-stack solution featuring:

- 🎫 Complete event management (CRUD operations)
- 👥 User management with validation
- 🔗 Event registration system with business rules
- 🔍 Advanced filtering and search capabilities
- 🌐 MVC frontend with responsive UI
- 🛡️ Comprehensive exception handling system
- 🧪 Extensive unit testing with Moq
- 📖 Auto-generated Swagger documentation

---

## 📁 Complete Project Structure

```
EventManagement/
├── 📁 Assets/                                    # Screenshots and documentation assets
│   ├── 🖼️ EVENT -POST.jpeg
│   ├── 🖼️ EVENT -PUT.jpeg
│   ├── 🖼️ Event-Delete.jpeg
│   ├── 🖼️ EVENT-GET BY ID.jpeg
│   ├── 🖼️ EVENTS FILTER BY LOCATION.jpeg
│   ├── 🖼️ EVENTS FILTER BY NAME.jpeg
│   ├── 🖼️ EVENTS- GET ALL.jpeg
│   ├── 🖼️ FILTER BY NAME &LOCATION.jpeg
│   ├── 🖼️ MVC EVENTS DETAILS.jpeg
│   ├── 🖼️ MVC-EVENTS.jpeg
│   ├── 🖼️ Registration -Delete.jpeg
│   ├── 🖼️ Registration -post.jpeg
│   ├── 🖼️ Registration-get by eventId.jpeg
│   ├── 🖼️ Registration-GetAll.jpeg
│   ├── 🖼️ Registration-GetByUserId.jpeg
│   ├── 🖼️ SWAGGER UI.jpeg
│   ├── 🖼️ unit test.png
│   ├── 🖼️ User -Get ALL.jpeg
│   ├── 🖼️ USER-DELETE.jpeg
│   ├── 🖼️ User-GetById.jpeg
│   ├── 🖼️ User-Post.jpeg
│   └── 🖼️ USER-PUT.jpeg
│
├── 📁 EventManagement.Core/                      # 🏛️ DOMAIN LAYER
│   ├── 📁 DTOs/                                  # Data Transfer Objects
│   │   ├── 📄 ErroResponseDTO.cs                 # Error response model
│   │   ├── 📄 EventRequestDTO.cs                 # Event creation/update request
│   │   ├── 📄 EventResponseDto.cs                # Event response model
│   │   ├── 📄 RegistrationRequest.cs             # Registration request model
│   │   ├── 📄 RegistrationResponseDto.cs         # Registration response model
│   │   ├── 📄 UserRequest.cs                     # User creation/update request
│   │   └── 📄 UserResponseDto.cs                 # User response model
│   │
│   ├── 📁 Entities/                              # Domain entities
│   │   ├── 📄 Event.cs                           # Event entity
│   │   ├── 📄 Registration.cs                    # Registration entity
│   │   └── 📄 User.cs                            # User entity
│   │
│   ├── 📁 Exceptions/                            # Custom exception types
│   │   ├── 📄 DuplicateEventException.cs         # Duplicate event exception
│   │   ├── 📄 DuplicateRegistrationException.cs  # Duplicate registration exception
│   │   ├── 📄 DuplicateUserException.cs          # Duplicate user exception
│   │   ├── 📄 EventCapacityExceededException.cs  # Event capacity exception
│   │   ├── 📄 InvalidDateException.cs            # Invalid date exception
│   │   ├── 📄 InvalidEmailException.cs           # Invalid email exception
│   │   ├── 📄 NotFoundException.cs               # Resource not found exception
│   │   └── 📄 ValidationException.cs             # Validation exception
│   │
│   ├── 📁 Interfaces/                            # Service and repository contracts
│   │   ├── 📄 IEventService.cs                   # Event service interface
│   │   ├── 📄 IRegistrationService.cs            # Registration service interface
│   │   ├── 📄 IRepository.cs                     # Generic repository interface
│   │   └── 📄 IUserService.cs                    # User service interface
│   │
│   └── 📄 EventManagement.Core.csproj            # Core project file
│
├── 📁 EventManagement.Application/               # 🔧 APPLICATION LAYER
│   ├── 📁 Services/                              # Business logic services
│   │   ├── 📄 EventService.cs                    # Event business logic
│   │   ├── 📄 Registration.cs                    # Registration service (RegistrationService)
│   │   └── 📄 UserService.cs                     # User business logic
│   │
│   └── 📄 EventManagement.Application.csproj     # Application project file
│
├── 📁 EventManagement.Infrastructure/            # 🗄️ INFRASTRUCTURE LAYER
│   ├── 📁 Repositories/                          # Data access implementations
│   │   ├── 📄 EventRepository.cs                 # Event data access
│   │   ├── 📄 RegistrationRepository.cs          # Registration data access
│   │   └── 📄 UserRepository.cs                  # User data access
│   │
│   └── 📄 EventManagement.Infrastructure.csproj  # Infrastructure project file
│
├── 📁 EventManagementAPI/                        # 🌐 WEB API LAYER
│   ├── 📁 Controllers/                           # API controllers
│   │   ├── 📄 EventController.cs                 # Event API endpoints
│   │   ├── 📄 HomeController.cs                  # Home API controller
│   │   ├── 📄 RegistrationController.cs          # Registration API endpoints
│   │   └── 📄 UserController.cs                  # User API endpoints
│   │
│   ├── 📁 Extension/                             # Extension methods
│   │   └── 📄 MiddlewareExtension.cs             # Middleware registration extensions
│   │
│   ├── 📁 Middleware/                            # Custom middleware
│   │   └── 📄 GlobalExceptionMiddleware.cs       # Global exception handling
│   │
│   ├── 📁 Properties/                            # Launch settings
│   │   └── 📄 launchSettings.json                # Development launch configuration
│   │
│   ├── 📁 Views/                                 # API views (if any)
│   │   ├── 📁 Events/
│   │   └── 📁 Shared/
│   │       └── 📄 _Layout.cshtml
│   │
│   ├── 📄 appsettings.Development.json           # Development configuration
│   ├── 📄 appsettings.json                       # Application configuration
│   ├── 📄 EventManagementAPI.csproj              # API project file
│   ├── 📄 EventManagementAPI.http                # HTTP test requests
│   └── 📄 Program.cs                             # Application entry point
│
├── 📁 EventManagement.MVC/                       # 🖥️ MVC FRONTEND LAYER
│   ├── 📁 Controllers/                           # MVC controllers
│   │   ├── 📄 EventViewControllercs.cs           # Events MVC controller
│   │   └── 📄 HomeController.cs                  # Home MVC controller
│   │
│   ├── 📁 Models/                                # View models
│   │   ├── 📄 ErrorViewModel.cs                  # Error view model
│   │   ├── 📄 EventViewModel.cs                  # Event view model
│   │   ├── 📄 RegistartionViewModel.cs           # Registration view model
│   │   ├── 📄 RegistrationApiResponse.cs         # API response model
│   │   └── 📄 UserViewModel.cs                   # User view model
│   │
│   ├── 📁 Properties/                            # Launch settings
│   │   └── 📄 launchSettings.json                # MVC launch configuration
│   │
│   ├── 📁 Views/                                 # Razor views
│   │   ├── 📁 Events/                            # Event views
│   │   │   ├── 📄 Details.cshtml                 # Event details view
│   │   │   ├── 📄 EventView.cshtml               # Event view template
│   │   │   └── 📄 Index.cshtml                   # Events list view
│   │   │
│   │   ├── 📁 Home/                              # Home views
│   │   │   ├── 📄 Index.cshtml                   # Home page
│   │   │   └── 📄 Privacy.cshtml                 # Privacy page
│   │   │
│   │   ├── 📁 Shared/                            # Shared views
│   │   │   ├── 📄 _Layout.cshtml                 # Main layout
│   │   │   ├── 📄 _Layout.cshtml.css             # Layout styles
│   │   │   ├── 📄 _ValidationScriptsPartial.cshtml # Validation scripts
│   │   │   └── 📄 Error.cshtml                   # Error page
│   │   │
│   │   ├── 📄 _ViewImports.cshtml                # Global view imports
│   │   └── 📄 _ViewStart.cshtml                  # View start configuration
│   │
│   ├── 📁 wwwroot/                               # Static files
│   │   ├── 📁 css/                               # Stylesheets
│   │   │   └── 📄 site.css                       # Custom styles
│   │   ├── 📁 js/                                # JavaScript files
│   │   │   └── 📄 site.js                        # Custom scripts
│   │   ├── 📁 lib/                               # Client libraries
│   │   │   ├── 📁 bootstrap/                     # Bootstrap framework
│   │   │   ├── 📁 jquery/                        # jQuery library
│   │   │   ├── 📁 jquery-validation/             # jQuery validation
│   │   │   └── 📁 jquery-validation-unobtrusive/ # Unobtrusive validation
│   │   └── 📄 favicon.ico                        # Site icon
│   │
│   ├── 📄 appsettings.Development.json           # MVC development settings
│   ├── 📄 appsettings.json                       # MVC application settings
│   ├── 📄 EventManagement.MVC.csproj             # MVC project file
│   └── 📄 Program.cs                             # MVC entry point
│
├── 📁 EventManagement.Tests/                     # 🧪 TESTING LAYER
│   ├── 📄 EventManagement.Tests.csproj           # Test project file
│   └── 📄 UnitTest1.cs                           # Unit tests
│
├── 📄 EventManagement.sln                        # Solution file
├── 📄 Readme.md                                  # Basic README
└── 📄 Updated readme file.md                     # Comprehensive README
```

---
---

## 📁 EventManagement.Core (Domain Layer)

### 📄 DTOs (Data Transfer Objects)

**ErroResponseDTO.cs**
```csharp
namespace EventManagement.Core.DTOs
{
    public class ErroResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
```

**EventRequestDTO.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.DTOs
{
    public class EventRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
```

**EventResponseDto.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.DTOs
{
    public class EventResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public required string Location { get; set; }
    }
}
```

**RegistrationRequest.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.DTOs
{
   public class RegistrationRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
```

**RegistrationResponseDto.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.DTOs
{
    public class RegistrationResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string EventTitle { get; set; } = string.Empty;
    }
}
```

**UserRequest.cs**
```csharp
namespace EventManagement.Core.DTOs
{
    public class UserRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
```

**UserResponseDto.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
```

### 📄 Entities (Domain Models)

**Event.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Entities
{
   public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
```

**Registration.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Entities
{
   public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User? User { get; set; }
        public Event? Event { get; set; }
    }
}
```

**User.cs**
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Entities
{
  public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
```

### 📄 Exceptions (Custom Exception Types)

**DuplicateEventException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class DuplicateEventException : Exception
    {
        public DuplicateEventException(string message) : base(message) { }
        public DuplicateEventException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**DuplicateRegistrationException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class DuplicateRegistrationException : Exception
    {
        public DuplicateRegistrationException(string message) : base(message) { }
        public DuplicateRegistrationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**DuplicateUserException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException(string message) : base(message) { }
        public DuplicateUserException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**EventCapacityExceededException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class EventCapacityExceededException : Exception
    {
        public EventCapacityExceededException(string message) : base(message) { }
        public EventCapacityExceededException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**InvalidDateException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException(string message) : base(message) { }
        public InvalidDateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**InvalidEmailException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**NotFoundException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

**ValidationException.cs**
```csharp
namespace EventManagement.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
```

### 📄 Interfaces (Service Contracts)

**IEventService.cs**
```csharp
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
```

**IRegistrationService.cs**
```csharp
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
```

**IRepository.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        T? GetById(int id);
        IEnumerable<T> GetAll();
    }
}
```

**IUserService.cs**
```csharp
using EventManagement.Core.Entities;
using EventManagement.Core.DTOs;

namespace EventManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserRequest request);
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task UpdateUserAsync(int id, UserRequest request);
        Task DeleteUserAsync(int id);
        // Legacy methods for MVC compatibility
        User? GetUserById(int id);
        IEnumerable<User> GetAllUsers();
    }
}
```

---

## 📁 EventManagement.Application (Application Layer)

### 📄 Services (Business Logic)

**EventService.cs**
```csharp
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
```

**Registration.cs (RegistrationService)**
```csharp
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
```

**UserService.cs**
```csharp
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using EventManagement.Core.Exceptions;
using EventManagement.Core.DTOs;

namespace EventManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUserAsync(UserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("User name is required");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ValidationException("User email is required");

            // Check for duplicate email
            var existingUser = _userRepository.GetAll().FirstOrDefault(u => u.Email.ToLower() == request.Email.ToLower());
            if (existingUser != null)
                throw new DuplicateUserException($"User with email '{request.Email}' already exists");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email
            };
                
            _userRepository.Add(user);
            return await Task.FromResult(user.Id);
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            
            var user = _userRepository.GetById(id);
            if (user == null) throw new NotFoundException($"User with ID {id} not found");
            
            return await Task.FromResult(MapToResponseDTO(user));
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = _userRepository.GetAll();
            return await Task.FromResult(users.Select(MapToResponseDTO));
        }

        public async Task UpdateUserAsync(int id, UserRequest request)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ValidationException("User name is required");
            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ValidationException("User email is required");
                
            var existing = _userRepository.GetById(id);
            if (existing == null) throw new NotFoundException($"User with ID {id} not found");
            
            existing.Name = request.Name;
            existing.Email = request.Email;
            
            _userRepository.Update(existing);
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            
            var existing = _userRepository.GetById(id);
            if (existing == null) throw new NotFoundException($"User with ID {id} not found");
            
            _userRepository.Delete(id);
            await Task.CompletedTask;
        }

        // Legacy methods for MVC compatibility
        public User? GetUserById(int id)
        {
            if (id <= 0) throw new ValidationException("Invalid user ID");
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        private UserResponseDto MapToResponseDTO(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
```

---

## 📁 EventManagement.Infrastructure (Infrastructure Layer)

### 📄 Repositories (Data Access)

**EventRepository.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Infrastructure.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private static readonly List<Event> _events = new();

        static EventRepository()
        {
            if (!_events.Any())
            {
                _events.AddRange(new List<Event>
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
                });
            }
        }

        public void Add(Event entity)
        {
            entity.Id = _events.Any() ? _events.Max(e => e.Id) + 1 : 1;
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
```

**RegistrationRepository.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Infrastructure.Repositories
{
    public class RegistrationRepository : IRepository<Registration>
    {
        private static readonly List<Registration> _registrations = new List<Registration>();

        static RegistrationRepository()
        {
            if (!_registrations.Any())
            {
                _registrations.AddRange(new List<Registration>
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
                });
            }
        }

        public void Add(Registration entity)
        {
            entity.Id = _registrations.Any() ? _registrations.Max(r => r.Id) + 1 : 1;
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
```

**UserRepository.cs**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;

namespace EventManagement.Infrastructure.Repositories
{
   public class UserRepository : IRepository<User>
    {
        private static readonly List<User> _users = new List<User>();
        
        static UserRepository()
        {
            if (!_users.Any())
            {
                _users.AddRange(new List<User>
                {
                    new User { Id = 1, Name = "Haripriya", Email = "haripriya@example.com" },
                    new User { Id = 2, Name = "Ram", Email = "ram@example.com" },
                    new User { Id = 3, Name = "Shiva", Email = "shiva@example.com" },
                    new User { Id = 4, Name = "Kavi", Email = "kavi@example.com" }
                });
            }
        }

        public void Add(User entity)
        {
            entity.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(entity);
        }

        public void Update(User entity) 
        {
            var existingUsers = _users.FirstOrDefault(b => b.Id == entity.Id);
            if (existingUsers != null)
            {
                existingUsers.Id = entity.Id;
                existingUsers.Name = entity.Name;
                existingUsers.Email = entity.Email;
            }
        }

        public void Delete(int id) 
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public User? GetById(int id)
        {
            return _users.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
```

---

## 📁 EventManagementAPI (Web API Layer)

### 📄 Controllers (API Endpoints)

**EventController.cs**
```csharp
using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.DTOs;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetAll()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventResponseDto>> GetById(int id)
    {
        var evt = await _eventService.GetEventByIdAsync(id);
        return Ok(evt);
    }

    [HttpPost]
    public async Task<ActionResult> Create(EventRequestDTO request)
    {
        var eventId = await _eventService.CreateEventAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = eventId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EventRequestDTO request)
    {
        await _eventService.UpdateEventAsync(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _eventService.DeleteEventAsync(id);
        return NoContent();
    }
}
```

**HomeController.cs**
```csharp
using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.Interfaces;
using EventManagement.Core.DTOs;

namespace EventManagementAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index(string searchTitle = "", string searchLocation = "")
        {
            var events = await _eventService.GetAllEventsAsync();
            
            if (!string.IsNullOrEmpty(searchTitle))
                events = events.Where(e => e.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase));
            
            if (!string.IsNullOrEmpty(searchLocation))
                events = events.Where(e => e.Location.Contains(searchLocation, StringComparison.OrdinalIgnoreCase));

            var eventDtos = events.Select(e => new EventResponseDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Location = e.Location
            });

            ViewBag.SearchTitle = searchTitle;
            ViewBag.SearchLocation = searchLocation;
            
            return View(eventDtos);
        }
    }
}
```

**RegistrationController.cs**
```csharp
using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Core.DTOs;
using EventManagement.Core.Entities;

[ApiController]
[Route("api/[controller]")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationsController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpGet("event/{eventId}")]
    public async Task<ActionResult<IEnumerable<RegistrationResponseDto>>> GetByEventId(int eventId)
    {
        var registrations = await _registrationService.GetRegistrationsByEventIdAsync(eventId);
        return Ok(registrations);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegistrationResponseDto>>> GetAll()
    {
        var registrations = await _registrationService.GetAllRegistrationsAsync();
        return Ok(registrations);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<RegistrationResponseDto>>> GetByUserId(int userId)
    {
        var registrations = await _registrationService.GetRegistrationsByUserIdAsync(userId);
        return Ok(registrations);
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegistrationRequest request)
    {
        var response = await _registrationService.RegisterUserForEventAsync(request);
        return CreatedAtAction(nameof(GetByEventId), new { eventId = request.EventId }, response);
    }

    [HttpDelete("{registrationId}")]
    public async Task<IActionResult> Delete(int registrationId)
    {
        await _registrationService.DeleteRegistrationAsync(registrationId);
        return NoContent();
    }
}
```

**UserController.cs**
```csharp
using EventManagement.Core.DTOs;
using EventManagement.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserRequest request)
    {
        var userId = await _userService.CreateUserAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = userId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserRequest request)
    {
        await _userService.UpdateUserAsync(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}
```

### 📄 Extension

**MiddlewareExtension.cs**
```csharp
namespace EventManagementAPI.Extension
{
    public class MiddlewareExtension
    {
    }
}
```

### 📄 Middleware

**GlobalExceptionMiddleware.cs**
```csharp
using EventManagement.Core.DTOs;
using EventManagement.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace EventManagementAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            var response = new ErroResponseDTO
            {
                Timestamp = DateTime.UtcNow
            };

            switch (exception)
            {
                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Resource not found";
                    response.Details = exception.Message;
                    break;
                case ValidationException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Validation failed";
                    response.Details = exception.Message;
                    break;
                case DuplicateRegistrationException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = "Duplicate registration";
                    response.Details = exception.Message;
                    break;
                case DuplicateUserException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = "Duplicate user";
                    response.Details = exception.Message;
                    break;
                case DuplicateEventException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = "Duplicate event";
                    response.Details = exception.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An error occurred while processing your request";
                    response.Details = exception.Message;
                    break;
            }

            context.Response.StatusCode = response.StatusCode;
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
```

### 📄 Program.cs (API)

```csharp
using EventManagement.Application.Services;
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using EventManagement.Infrastructure.Repositories;
using EventManagement.Services;
using EventManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection - Repositories (Singleton for data persistence)
builder.Services.AddSingleton<IRepository<Event>, EventRepository>();
builder.Services.AddSingleton<IRepository<User>, UserRepository>();
builder.Services.AddSingleton<IRepository<Registration>, RegistrationRepository>();

// Dependency Injection - Services
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

var app = builder.Build();

// Configure middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

---

## 📁 EventManagement.MVC (MVC Frontend Layer)

### 📄 Controllers

**EventViewControllercs.cs (EventsController)**
```csharp
using Microsoft.AspNetCore.Mvc;
using EventManagement.MVC.Models;
using System.Text.Json;

namespace EventManagement.MVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7282/api";

        public EventsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(string searchTerm, string location)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_apiBaseUrl}/events");
                var events = JsonSerializer.Deserialize<List<EventViewModel>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<EventViewModel>();
                
                // Apply filtering
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    events = events.Where(e => e.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || 
                                              e.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                
                if (!string.IsNullOrEmpty(location))
                {
                    events = events.Where(e => e.Location.Contains(location, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                
                ViewBag.SearchTerm = searchTerm;
                ViewBag.Location = location;
                return View(events);
            }
            catch
            {
                var events = new List<EventViewModel>
                {
                    new EventViewModel { Id = 1, Title = "ASP.NET Core Workshop", Description = "Backend development with .NET", Date = new DateTime(2025, 8, 30, 10, 0, 0), Location = "Chennai" }
                };
                return View(events);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var eventResponse = await _httpClient.GetStringAsync($"{_apiBaseUrl}/events/{id}");
                var eventItem = JsonSerializer.Deserialize<EventViewModel>(eventResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                var registrationsResponse = await _httpClient.GetStringAsync($"{_apiBaseUrl}/registrations/event/{id}");
                var registrations = JsonSerializer.Deserialize<List<RegistrationApiResponse>>(registrationsResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                var registrationViewModels = registrations?.Select(r => new RegistartionViewModel
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    UserName = r.UserName ?? $"User {r.UserId}",
                    EventId = r.EventId,
                    RegistrationDate = r.RegistrationDate
                }).ToList() ?? new List<RegistartionViewModel>();

                ViewBag.Event = eventItem;
                return View(registrationViewModels);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
```

**HomeController.cs (MVC)**
```csharp
using EventManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventManagement.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
```

### 📄 Models (View Models)

**ErrorViewModel.cs**
```csharp
namespace EventManagement.MVC.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
```

**EventViewModel.cs**
```csharp
namespace EventManagement.MVC.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
```

**RegistartionViewModel.cs**
```csharp
namespace EventManagement.MVC.Models
{
    public class RegistartionViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
```

**RegistrationApiResponse.cs**
```csharp
namespace EventManagement.MVC.Models
{
    public class RegistrationApiResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int EventId { get; set; }
        public string? EventTitle { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
```

**UserViewModel.cs**
```csharp
namespace EventManagement.MVC.Models
{
    public class UserViewModel
    {
    }
}
```

### 📄 Views (Razor Pages)

**Index.cshtml (Events List)**
```html
@model List<EventManagement.MVC.Models.EventViewModel>

@{
    ViewData["Title"] = "Events List";
}

<div class="container mt-4">
    <h2> Event Management System</h2>
    <p class="lead">Browse all available technical events</p>
    
    <!-- Search Form -->
    <div class="card mb-4">
        <div class="card-body">
            <form method="get" asp-action="Index">
                <div class="row g-3">
                    <div class="col-md-5">
                        <label for="searchTerm" class="form-label">Search Events</label>
                        <input type="text" class="form-control" id="searchTerm" name="searchTerm" 
                               value="@ViewBag.SearchTerm" placeholder="Search by title or description...">
                    </div>
                    <div class="col-md-4">
                        <label for="location" class="form-label">Location</label>
                        <input type="text" class="form-control" id="location" name="location" 
                               value="@ViewBag.Location" placeholder="Filter by location...">
                    </div>
                    <div class="col-md-3 d-flex align-items-end">
                        <button type="submit" class="btn btn-primary me-2">Search</button>
                        <a asp-action="Index" class="btn btn-outline-secondary">Clear</a>
                    </div>
                </div>
            </form>
        </div>
    </div>
    
    <div class="table-responsive">
        <table class="table table-striped table-hover">
            <thead class="table-dark">
                <tr>
                    <th>ID</th>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Date</th>
                    <th>Location</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var evt in Model)
                {
                    <tr>
                        <td>@evt.Id</td>
                        <td><strong>@evt.Title</strong></td>
                        <td>@evt.Description</td>
                        <td>@evt.Date.ToString("MMM dd, yyyy HH:mm")</td>
                        <td><span class="badge bg-primary">@evt.Location</span></td>
                        <td>
                            <a asp-action="Details" asp-route-id="@evt.Id" class="btn btn-sm btn-info">Details</a>
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>
    
    @if (!Model.Any())
    {
        <div class="alert alert-info">
            <h4>No Events Found</h4>
            <p>There are currently no events available.</p>
        </div>
    }
</div>
```

**Details.cshtml (Event Details)**
```html
@model List<EventManagement.MVC.Models.RegistartionViewModel>

@{
    ViewData["Title"] = "Event Details";
    var eventItem = ViewBag.Event as EventManagement.MVC.Models.EventViewModel;
}

<div class="container mt-4">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a asp-action="Index">Events</a></li>
            <li class="breadcrumb-item active">@eventItem.Title</li>
        </ol>
    </nav>

    <div class="card mb-4">
        <div class="card-header">
            <h3>🎆 @eventItem.Title</h3>
        </div>
        <div class="card-body">
            <p><strong>Description:</strong> @eventItem.Description</p>
            <p><strong>Date:</strong> @eventItem.Date.ToString("MMM dd, yyyy HH:mm")</p>
            <p><strong>Location:</strong> <span class="badge bg-primary">@eventItem.Location</span></p>
        </div>
    </div>

    <h4>👥 Registered Users (@Model.Count)</h4>
    
    @if (Model.Any())
    {
        <div class="table-responsive">
            <table class="table table-striped">
                <thead class="table-secondary">
                    <tr>
                        <th>Registration ID</th>
                        <th>User Name</th>
                        <th>Registration Date</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var registration in Model)
                    {
                        <tr>
                            <td>@registration.Id</td>
                            <td>@registration.UserName</td>
                            <td>@registration.RegistrationDate.ToString("MMM dd, yyyy HH:mm")</td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    }
    else
    {
        <div class="alert alert-info">
            <h5>No Registrations Yet</h5>
            <p>No users have registered for this event.</p>
        </div>
    }

    <div class="mt-3">
        <a asp-action="Index" class="btn btn-secondary">← Back to Events</a>
    </div>
</div>
```

### 📄 Program.cs (MVC)

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Configure HttpClient to ignore SSL certificate errors for development
builder.Services.ConfigureHttpClientDefaults(http =>
{
    http.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

---

## 📁 EventManagement.Tests (Testing Layer)

### 📄 UnitTest1.cs

```csharp
using EventManagement.Core.Entities;
using EventManagement.Core.Interfaces;
using EventManagement.Core.DTOs;
using EventManagement.Services;
using Moq;

namespace EventManagement.Tests;

public class RegistrationServiceTests
{
    private readonly Mock<IRepository<Registration>> _mockRegistrationRepository;
    private readonly Mock<IRepository<User>> _mockUserRepository;
    private readonly Mock<IRepository<Event>> _mockEventRepository;
    private readonly RegistrationService _service;

    public RegistrationServiceTests()
    {
        _mockRegistrationRepository = new Mock<IRepository<Registration>>();
        _mockUserRepository = new Mock<IRepository<User>>();
        _mockEventRepository = new Mock<IRepository<Event>>();
        _service = new RegistrationService(_mockRegistrationRepository.Object, _mockUserRepository.Object, _mockEventRepository.Object);
    }

    [Fact]
    public void RegisterUserForEvent_ShouldCallRepositoryAdd()
    {
        // Arrange
        var registration = new Registration { Id = 1, UserId = 1, EventId = 1, RegistrationDate = DateTime.Now };

        // Act
        _service.RegisterUserForEvent(registration);

        // Assert
        _mockRegistrationRepository.Verify(r => r.Add(registration), Times.Once);
    }

    [Fact]
    public void GetRegistrationsByEventId_ShouldReturnFilteredRegistrations()
    {
        // Arrange
        var registrations = new List<Registration>
        {
            new Registration { Id = 1, UserId = 1, EventId = 1, RegistrationDate = DateTime.Now },
            new Registration { Id = 2, UserId = 2, EventId = 1, RegistrationDate = DateTime.Now },
            new Registration { Id = 3, UserId = 3, EventId = 2, RegistrationDate = DateTime.Now }
        };
        _mockRegistrationRepository.Setup(r => r.GetAll()).Returns(registrations);

        // Act
        var result = _service.GetRegistrationsByEventId(1);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.All(result, r => Assert.Equal(1, r.EventId));
    }

    [Fact]
    public async Task RegisterUserForEventAsync_ShouldThrowDuplicateException_WhenAlreadyRegistered()
    {
        // Arrange
        var existingRegistrations = new List<Registration>
        {
            new Registration { Id = 1, UserId = 1, EventId = 1, RegistrationDate = DateTime.Now }
        };
        _mockRegistrationRepository.Setup(r => r.GetAll()).Returns(existingRegistrations);
        var request = new RegistrationRequest { UserId = 1, EventId = 1 };

        // Act & Assert
        await Assert.ThrowsAsync<EventManagement.Core.Exceptions.DuplicateRegistrationException>(
            () => _service.RegisterUserForEventAsync(request));
    }

    [Fact]
    public async Task RegisterUserForEventAsync_ShouldThrowValidationException_WhenInvalidUserId()
    {
        // Arrange
        var request = new RegistrationRequest { UserId = 0, EventId = 1 };

        // Act & Assert
        await Assert.ThrowsAsync<EventManagement.Core.Exceptions.ValidationException>(
            () => _service.RegisterUserForEventAsync(request));
    }

    [Fact]
    public async Task GetAllRegistrationsAsync_ShouldReturnAllRegistrations()
    {
        // Arrange
        var registrations = new List<Registration>
        {
            new Registration { Id = 1, UserId = 1, EventId = 1, RegistrationDate = DateTime.Now },
            new Registration { Id = 2, UserId = 2, EventId = 2, RegistrationDate = DateTime.Now }
        };
        _mockRegistrationRepository.Setup(r => r.GetAll()).Returns(registrations);
        _mockUserRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(new User { Name = "Test User", Email = "test@example.com" });
        _mockEventRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(new Event { Title = "Test Event" });

        // Act
        var result = await _service.GetAllRegistrationsAsync();

        // Assert
        Assert.Equal(2, result.Count());
    }
}
```

---

## 🚦 Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
```bash
git clone <repository-url>
cd EventManagement
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Build the solution**
```bash
dotnet build
```

4. **Run tests**
```bash
dotnet test
```

5. **Start the API**
```bash
dotnet run --project EventManagementAPI
```

6. **Start the MVC app**
```bash
dotnet run --project EventManagement.MVC
```

### Access Points
- **API Swagger**: `https://localhost:7282/swagger`
- **MVC App**: `https://localhost:7283`

---


## 👨💻 Author

**Hari Ram L**