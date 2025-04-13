

namespace Instagram_Backend.Controllers;

using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LikesController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikesController(ILikeService likeService)
    {
        _likeService = likeService;
    }

    [HttpPost("posts/{postId:guid}/toggle")]
    [Authorize]
    public async Task<IActionResult> ToggleLikePost(Guid postId)
    {
        var userId = GetUserIdFromToken();

        if (postId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        var result = await _likeService.ToggleLikePostAsync(postId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Post with ID {postId} liked/unliked successfully",
            Data = result,
        });
    }
    [HttpPost("comments/{commentId:guid}/toggle")]
    [Authorize]
    public async Task<IActionResult> ToggleLikeComment(Guid commentId)
    {
        var userId = GetUserIdFromToken();

        if (commentId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment ID.",
                Data = false,
            });

        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        var result = await _likeService.ToggleLikeCommentAsync(commentId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Comment with ID {commentId} liked/unliked successfully",
            Data = result,
        });
    }
    [HttpGet("posts/{postId:guid}/users")]
    [Authorize]
    public async Task<IActionResult> GetUsersWhoLikedPost(Guid postId,  int pageNumber = 1, int pageSize = 10)
    {
        var userId = GetUserIdFromToken();

        if (postId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        var result = await _likeService.GetUsersWhoLikedPostAsync(postId, userId ,  pageNumber, pageSize);
        return Ok(new ApiResponse<PagedResult<UserDto>>
        {
            Message = $"Users who liked post with ID {postId} retrieved successfully",
            Data = result,
        });
    }
    // only accessible by the user himself
    // to prevent other users from seeing the liked posts of a user
    [HttpGet("users/myposts")]
    [Authorize]
    public async Task<IActionResult> GetLikedPostsByUser( int pageNumber = 1, int pageSize = 10)
    {
        var currentUserId = GetUserIdFromToken();

        if (currentUserId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });


        var result = await _likeService.GetLikedPostsByUserAsync(currentUserId , pageNumber, pageSize);
        return Ok(new ApiResponse<PagedResult<PostDto>>
        {
            Message = $"Liked posts by user with ID {currentUserId} retrieved successfully",
            Data = result,
        });
    }

    [HttpGet("posts/{postId:guid}/isliked")]
    [Authorize]
    public async Task<IActionResult> IsPostLikedByUser(Guid postId)
    {
        var userId = GetUserIdFromToken();

        if (postId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        var result = await _likeService.IsPostLikedByUserAsync(postId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Post with ID {postId} liked status retrieved successfully",
            Data = result,
        });
    }

    [HttpGet("comments/{commentId:guid}/isliked")]
    [Authorize]
    public async Task<IActionResult> IsCommentLikedByUser(Guid commentId)
    {
        var userId = GetUserIdFromToken();

        if (commentId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment ID.",
                Data = false,
            });

        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        var result = await _likeService.IsCommentLikedByUserAsync(commentId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Comment with ID {commentId} liked status retrieved successfully",
            Data = result,
        });
    }



    private Guid GetUserIdFromToken()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
    }


}