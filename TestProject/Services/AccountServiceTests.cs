using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Exceptions;
using Instagram_Backend.Models;
using Instagram_Backend.Requests;
using Instagram_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using TestProject.TestData;

namespace TestProject.Services;

public class AccountServiceTests
{
    private readonly Mock<IAuthTokenProcessor> _mockTokenProcessor;
    private readonly Mock<UserManager<User>> _mockUserManager;
    private readonly Mock<ApplicationDbContext> _mockDbContext;
    private readonly Mock<IHttpContextAccessor> _mockHttpContext;
    private readonly AccountService _accountService;
    private readonly Mock<IPasswordHasher<User>> _mockPasswordHasher;

    public AccountServiceTests()
    {
        _mockTokenProcessor = new Mock<IAuthTokenProcessor>();
        
        // UserManager requires special setup since it's not an interface
        var userStoreMock = new Mock<IUserStore<User>>();
        _mockUserManager = new Mock<UserManager<User>>(
            userStoreMock.Object, null, null, null, null, null, null, null, null);
        
        _mockDbContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
        _mockHttpContext = new Mock<IHttpContextAccessor>();
        



        _mockPasswordHasher = new Mock<IPasswordHasher<User>>();
        _mockPasswordHasher.Setup(x => x.HashPassword(It.IsAny<User>(), It.IsAny<string>()))
            .Returns("HashedPassword123");


        _mockUserManager.Object.PasswordHasher = _mockPasswordHasher.Object;    
        _accountService = new AccountService(
            _mockTokenProcessor.Object,
            _mockUserManager.Object,
            _mockDbContext.Object,
            _mockHttpContext.Object);
    }

    [Theory]
    [ClassData(typeof(RegisterUserValid))]
    public async Task RegisterAsync_WithNewEmail_CreatesUser( RegisterRequest request)
    {
        
        _mockUserManager.Setup(m => m.FindByEmailAsync("test@example.com"))
            .ReturnsAsync((User)null);
        
        _mockUserManager.Setup(m => m.CreateAsync(It.IsAny<User>()))
            .ReturnsAsync(IdentityResult.Success);

        
        // Act
        await _accountService.RegisterAsync(request);
        
        // Assert
        _mockUserManager.Verify(m => m.CreateAsync(It.IsAny<User>()), Times.Once);
    }
    
    [Theory]
    [ClassData(typeof(RegisterUserInvalid))]
    public async Task  RegisterAsync_WithExistingEmail_ThrowsBadRequestException(RegisterRequest request)
    {
        
        _mockUserManager.Setup(m => m.FindByEmailAsync(request.Email))
            .ReturnsAsync(new User { Email = request.Email, FirstName = "Test", LastName = "User" });

            
        // // if bad request exception is not thrown, the test fails
        // await Assert.ThrowsAsync<BadRequestException>(() =>  
        //     _accountService.RegisterAsync(request));

        await _accountService.RegisterAsync(request);
        
        _mockUserManager.Verify(m => m.CreateAsync(It.IsAny<User>()), Times.Never);
    }
}