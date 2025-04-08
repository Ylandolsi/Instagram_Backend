using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Controllers;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetPost(Guid id)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized( new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });
        

        if ( id == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        var post = await _postService.GetPostByIdAsync(id , userId);
        return Ok(new ApiResponse<PostDto>
        {
            Message = $"Post with ID {id} fetched successfully",
            Data = post,
        });
    }

    [HttpGet("user/{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetUserPosts(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var currentUserId = GetUserIdFromToken();
        if (currentUserId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });
        
        if (userId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid user ID.",
                Data = false,
            });
        
        var posts = await _postService.GetPostsByUserIdAsync(userId, page, pageSize , currentUserId);
        return Ok( new ApiResponse<PagedResult<PostDto>>
        {
            Message = $"Posts of user with ID {userId} fetched successfully",
            Data = posts,
        });
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllPosts([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var currentUserId = GetUserIdFromToken();
        if (currentUserId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });
        
        var posts = await _postService.GetAllPostsAsync(page, pageSize , currentUserId);
        return Ok( new ApiResponse<PagedResult<PostDto>>
        {
            Message = $"All posts fetched successfully",
            Data = posts,
        });
    }

    [HttpPost]  
    [Authorize]
    public async Task<IActionResult> CreatePost([FromForm] CreatePostDto postDto,[FromForm] List<IFormFile> file)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if ( !ModelState.IsValid)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post data.",
                Data = false,
            });

        var result = await _postService.CreatePostAsync(postDto, file, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Post created successfully",
            Data = result,
        });
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> UpdatePost(Guid id, [FromBody] UpdatePostDto postDto)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (id == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        if ( !ModelState.IsValid)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post data.",
                Data = false,
            });

        var result = await _postService.UpdatePostAsync(postDto, id, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Post with ID {id} updated successfully",
            Data = result,
        });
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (id == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        var result = await _postService.DeletePostAsync(id, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = $"Post with ID {id} deleted successfully",
            Data = result,
        });
    }



   
    private Guid GetUserIdFromToken()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
    }
}