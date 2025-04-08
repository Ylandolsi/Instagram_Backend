// using Instagram_Backend.Dtos;
// using Microsoft.AspNetCore.Http;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace Instagram_Backend.Abstracts ; 

// public interface IStoryService
// {
//     Task<StoryDto> CreateStoryAsync(IFormFile media, Guid userId);
//     Task<List<StoryDto>> GetUserStoriesAsync(Guid userId, Guid viewerId);
//     Task<StoryDto> ViewStoryAsync(Guid storyId, Guid viewerId);
//     Task<List<StoryGroupDto>> GetStoriesFeedAsync(Guid userId);
//     Task<bool> DeleteStoryAsync(Guid storyId, Guid userId);
//     Task<bool> CleanExpiredStoriesAsync();
// }