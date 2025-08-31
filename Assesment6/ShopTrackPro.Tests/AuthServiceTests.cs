using Moq;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.DTOs.Auth;
using ShopTrackPro.Core.DTOs.User;
using ShopTrackPro.Core.Exceptions;

namespace ShopTrackPro.Tests;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> mockRepository;
    private readonly AuthService service;

    public AuthServiceTests()
    {
        mockRepository = new Mock<IUserRepository>();
        service = new AuthService(mockRepository.Object);
    }

    [Fact]
    public async Task RegisterAsync_ValidUser_ReturnsUserDto()
    {
        // Arrange
        var registerDto = new RegisterDto
        {
            Username = "testuser",
            Email = "test@example.com",
            Password = "password123",
            Role = "Customer"
        };
        var user = new User { Id = 1, Username = "testuser", Email = "test@example.com", Role = "Customer" };

        mockRepository.Setup(r => r.UsernameExistsAsync("testuser")).ReturnsAsync(false);
        mockRepository.Setup(r => r.EmailExistsAsync("test@example.com")).ReturnsAsync(false);
        mockRepository.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(user);

        // Act
        var result = await service.RegisterAsync(registerDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("testuser", result.Username);
        Assert.Equal("test@example.com", result.Email);
    }

    [Fact]
    public async Task RegisterAsync_ExistingUsername_ThrowsException()
    {
        // Arrange
        var registerDto = new RegisterDto
        {
            Username = "existinguser",
            Email = "test@example.com",
            Password = "password123",
            Role = "Customer"
        };

        mockRepository.Setup(r => r.UsernameExistsAsync("existinguser")).ReturnsAsync(true);

        // Act & Assert
        await Assert.ThrowsAsync<DuplicateEmailException>(() => service.RegisterAsync(registerDto));
    }

    [Fact]
    public async Task LoginAsync_InvalidCredentials_ThrowsException()
    {
        // Arrange
        var loginDto = new LoginDto { Username = "invalid", Password = "wrong" };
        mockRepository.Setup(r => r.GetByUsernameAsync("invalid")).ReturnsAsync((User?)null);

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedException>(() => service.LoginAsync(loginDto));
    }

    [Fact]
    public async Task ValidateTokenAsync_InvalidToken_ReturnsFalse()
    {
        // Act
        var result = await service.ValidateTokenAsync("invalid.token.here");

        // Assert
        Assert.False(result);
    }
}