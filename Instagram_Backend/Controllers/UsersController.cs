using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService= userService;
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var currentUserId = GetUserIdFromToken();
        if (currentUserId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });
        if (id == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "UserId is empty",
                Data = false,
            });
        var user = await _userService.GetUserById(id , currentUserId);
        if (user == null)
            return NotFound(new ApiResponse<bool>
            {
                Message = $"User with id {id} not found",
                Data = false,
            });
        return Ok(new ApiResponse<UserDto>
        {
            Message = $"User with id {id} fetched successfully",
            Data = user,
        });
    }
    
    [HttpGet("{id:guid}/followers")]
    public async Task<IActionResult> GetFollowers(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        Guid userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });
        var followers = await _userService.GetMyFollowers(page, pageSize, id , userId);
        return Ok(new ApiResponse<PagedResult<UserDto>>
        {
            Message = $"Followers of userId = {id} Fetched with success",
            Data = followers ,
        });
    }

    [HttpGet("{id:guid}/following")]
    public async Task<IActionResult> GetFollowing(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        Guid userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });
        var following = await _userService.GetMyFollowing(page, pageSize, id,userId);
        return Ok( new ApiResponse<PagedResult<UserDto>>
        {
            Message = $"Following of userId = {id} Fetched with success",
            Data = following ,
        });
    }

    [HttpPost("{id:guid}/follow")]
    [Authorize]
    public async Task<IActionResult> FollowUser(Guid id)
    {
        var userId = GetUserIdFromToken();

        if ( userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });


        if (userId == id)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "You cannot follow yourself.",
                Data = false,
            });
            
        
        var result = await _userService.FollowUser(userId, id);
        return Ok( new ApiResponse<object>
        {
            Message = $"UserId = {userId} Followed UserId = {id} with success " ,
            Data = new
            {
                UserId = userId,
                FollowedUserId = id
            } ,
        });
    }
    [HttpPost("{id:guid}/unfollow")]
    [Authorize]
    public async Task<IActionResult> UnfollowUser(Guid id)
    {
        var userId = GetUserIdFromToken();

        if ( userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });


        if (userId == id)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "You cannot Unfollow yourself.",
                Data = false,
            });


         await _userService.UnfollowUser(userId, id);
        return Ok( new ApiResponse<object>
        {
            Message = $"UserId = {userId} Unfollowed UserId = {id} with success " ,
            Data = new
            {
                UserId = userId,
                UnfollowedUserId = id
            } ,
        });
    }

    [HttpGet("search")]
    public async Task<ActionResult> SearchUsers(
        [FromQuery] string query,
        [FromQuery] int page = 1, 
        [FromQuery] int pageSize = 10)
    {
        if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Data = false,
                Message = "Search query must be at least 2 characters long"
            });
        }

        var currentUserId = GetUserIdFromToken();
        var result = await _userService.SearchUsersAsync(query, page, pageSize, currentUserId);

        return Ok(new ApiResponse<PagedResult<UserDto>>
        {
            Data = result,
            Message = "Users found successfully"
        });
    }

    private Guid GetUserIdFromToken()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
    }
    
}