
using System.Security.Claims;
using Instagram_Backend.Abstracts;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;
using Microsoft.AspNetCore.Mvc;

namespace Instagram_Backend.Controllers;    

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly ILogger<CommentsController> _logger;

    public CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
    {
        _commentService = commentService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createCommentDto)
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
                Message = "Invalid comment data.",
                Data = false,
            });
        if (createCommentDto.PostId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });
        

        var result = await _commentService.CreateCommentAsync(createCommentDto,createCommentDto.PostId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = result ? "Comment created successfully." : "Failed to create comment.",
            Data = result,
        });


    }

    [HttpGet("posts/{postId:guid}")]
    public async Task<IActionResult> GetPostCommentsRoot(Guid postId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (postId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid post ID.",
                Data = false,
            });

        var comments = await _commentService.GetPostCommentsRootAsync(postId, page, pageSize , userId);
        return Ok(new ApiResponse<PagedResult<CommentDto>>
        {
            Message = $"Comments for post {postId} fetched successfully.",
            Data = comments,
        });
    }

    [HttpGet("replies/{commentId:guid}")]
    public async Task<IActionResult> GetCommentReplies(Guid commentId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (commentId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment ID.",
                Data = false,
            });

        var replies = await _commentService.GetCommentRepliesAsync(commentId, page, pageSize , userId);
        return Ok(new ApiResponse<PagedResult<CommentDto>>
        {
            Message = $"Replies for comment {commentId} fetched successfully.",
            Data = replies,
        });
    }

    [HttpGet]
    [Route("{commentId:guid}")]
    public async Task<IActionResult> GetCommentById(Guid commentId)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (commentId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment ID.",
                Data = false,
            });

        var comment = await _commentService.GetCommentByIdAsync(commentId , userId);
        return Ok(new ApiResponse<CommentDto>
        {
            Message = $"Comment with ID {commentId} fetched successfully.",
            Data = comment,
        });
    }

    [HttpPut]
    [Route("{commentId:guid}")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateCommentDto, Guid commentId)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (commentId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment ID.",
                Data = false,
            });

        if ( !ModelState.IsValid)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment data.",
                Data = false,
            });

        var result = await _commentService.UpdateCommentAsync(updateCommentDto, commentId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = result != null ? "Comment updated successfully." : "Failed to update comment.",
            Data = result != null ? true : false,
        });
    }

    [HttpDelete]
    [Route("{commentId:guid}")]
    public async Task<IActionResult> DeleteComment(Guid commentId)
    {
        var userId = GetUserIdFromToken();
        if (userId == Guid.Empty)
            return Unauthorized(new ApiResponse<bool>
            {
                Message = "User not authenticated.",
                Data = false,
            });

        if (commentId == Guid.Empty)
            return BadRequest(new ApiResponse<bool>
            {
                Message = "Invalid comment ID.",
                Data = false,
            });

        var result = await _commentService.DeleteCommentAsync(commentId, userId);
        return Ok(new ApiResponse<bool>
        {
            Message = result ? "Comment deleted successfully." : "Failed to delete comment.",
            Data = result,
        });
    }

    





    private Guid GetUserIdFromToken()
    {
        var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
    }

}
