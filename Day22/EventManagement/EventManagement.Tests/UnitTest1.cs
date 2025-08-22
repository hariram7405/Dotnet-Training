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