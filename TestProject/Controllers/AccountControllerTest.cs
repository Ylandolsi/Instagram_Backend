// using Instagram_Backend.Abstracts;
// using Instagram_Backend.Controllers;
// using Instagram_Backend.Models;
// using Instagram_Backend.Requests;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Moq;

// namespace TestProject.Controllers;

// public class AccountControllerTests
// {
//     private readonly Mock<IAccountService> _mockAccountService;
//     private readonly Mock<IAuthTokenProcessor> _mockAuthTokenProcessor;
//     private readonly Mock<SignInManager<User>> _mockSignInManager;
//     private readonly AccountController _controller;

//     public AccountControllerTests()
//     {
//         _mockAccountService = new Mock<IAccountService>();
//         _mockAuthTokenProcessor = new Mock<IAuthTokenProcessor>();
        
//         // SignInManager requires special setup
//         var userStoreMock = new Mock<IUserStore<User>>();
//         var userManagerMock = new Mock<UserManager<User>>(
//             userStoreMock.Object, null, null, null, null, null, null, null, null);
        
//         var contextAccessorMock = new Mock<IHttpContextAccessor>();
//         var claimsFactoryMock = new Mock<IUserClaimsPrincipalFactory<User>>();
        
//         _mockSignInManager = new Mock<SignInManager<User>>(
//             userManagerMock.Object, 
//             contextAccessorMock.Object, 
//             claimsFactoryMock.Object, 
//             null, null, null, null);
        
//         _controller = new AccountController(
//             _mockAccountService.Object,
//             _mockAuthTokenProcessor.Object,
//             _mockSignInManager.Object);
//     }

//     [Fact]
//     public async Task Register_WithValidData_ReturnsOk()
//     {
//         // Arrange
//         var request = new RegisterRequest
//         {
//             Email = "test@example.com",
//             FirstName = "Test",
//             LastName = "User",
//             Password = "P@ssword1",
//             ConfirmPassword = "P@ssword1"
//         };
        
//         // Act
//         var result = await _controller.Register(request);
        
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         Assert.Equal(200, okResult.StatusCode);
        
//         _mockAccountService.Verify(
//             service => service.RegisterAsync(request), 
//             Times.Once);
//     }
    
//     [Fact]
//     public async Task Login_WithValidCredentials_ReturnsOk()
//     {
//         // Arrange
//         var request = new LoginRequest
//         {
//             Email = "test@example.com",
//             Password = "P@ssword1"
//         };
        
//         // Act
//         var result = await _controller.Login(request);
        
//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         Assert.Equal(200, okResult.StatusCode);
        
//         _mockAccountService.Verify(
//             service => service.LoginAsync(request), 
//             Times.Once);
//     }
// }