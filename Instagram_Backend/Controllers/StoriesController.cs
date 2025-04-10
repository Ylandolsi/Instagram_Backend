// using Instagram_Backend.Abstracts;
// using Instagram_Backend.Dtos;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Threading.Tasks;

// namespace Instagram_Backend.Controllers; 

// [ApiController]
// [Route("api/[controller]")]
// [Authorize]
// public class StoriesController : ControllerBase
// {
//     private readonly IStoryService _storyService;
//     private readonly IUserService _userService;

//     public StoriesController(IStoryService storyService, IUserService userService)
//     {
//         _storyService = storyService;
//         _userService = userService;
//     }

//     [HttpPost]
//     public async Task<IActionResult> CreateStory([FromForm] IFormFile media, [FromForm] CreateStoryDto dto)
//     {
//         var userId = _userService.GetCurrentUserId(User);
//         var story = await _storyService.CreateStoryAsync(media, userId, dto.IsImage);
//         return Ok(story);
//     }

//     [HttpGet("feed")]
//     public async Task<IActionResult> GetStoriesFeed()
//     {
//         var userId = _userService.GetCurrentUserId(User);
//         var stories = await _storyService.GetStoriesFeedAsync(userId);
//         return Ok(stories);
//     }

//     [HttpGet("user/{userId}")]
//     public async Task<IActionResult> GetUserStories(Guid userId)
//     {
//         var currentUserId = _userService.GetCurrentUserId(User);
//         var stories = await _storyService.GetUserStoriesAsync(userId, currentUserId);
//         return Ok(stories);
//     }

//     [HttpPost("{storyId}/view")]
//     public async Task<IActionResult> ViewStory(Guid storyId)
//     {
//         var userId = _userService.GetCurrentUserId(User);
//         var story = await _storyService.ViewStoryAsync(storyId, userId);
//         return Ok(story);
//     }

//     [HttpDelete("{storyId}")]
//     public async Task<IActionResult> DeleteStory(Guid storyId)
//     {
//         var userId = _userService.GetCurrentUserId(User);
//         var result = await _storyService.DeleteStoryAsync(storyId, userId);
//         return Ok(result);
//     }
// }