// using Instagram_Backend.Abstracts;
// using Instagram_Backend.Data;
// using Instagram_Backend.Dtos;
// using Instagram_Backend.Exceptions;
// using Instagram_Backend.Models;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Instagram_Backend.Services ; 


// public class StoryService : IStoryService
// {
//     private readonly ApplicationDbContext _context;
//     private readonly ILogger<StoryService> _logger;
//     private readonly IImageService _imageService;
//     private readonly CloudinaryService _cloudinaryService;


//     public StoryService(
//         ApplicationDbContext context,
//         ILogger<StoryService> logger,
//         IImageService imageService , 
//         CloudinaryService cloudinaryService)
//     {
//         _context = context;
//         _logger = logger;
//         _imageService = imageService;
//         _cloudinaryService = cloudinaryService;
//     }

//     public async Task<StoryDto> CreateStoryAsync(IFormFile media, Guid userId)
//     {
//         if (media == null || media.Length == 0)
//         {
//             throw new BadRequestException("Media file is required");
//         }

//         _imageService.VerifyFileImage(media);
        

//         var user = await _context.Users.FindAsync(userId);
//         if (user == null)
//         {
//             throw new NotFoundException($"User with ID {userId} not found");
//         }

//         var uploadResult = await _cloudinaryService.UploadFileAsync(image);

//         if (uploadResult == null)
//         {
//             throw new Exception("Failed to upload media file");
//         }


//         var story = new Story
//         {
//             Id = Guid.NewGuid(),
//             UserId = userId,
//             MediaUrl = uploadResult.SecureUrl.ToString(),,
//             CreatedAt = DateTime.UtcNow,
//             ExpiresAt = DateTime.UtcNow.AddHours(24)
//         };

//         _context.Stories.Add(story);
//         await _context.SaveChangesAsync();

//         return new StoryDto
//         {
//             Id = story.Id,
//             UserId = story.UserId,
//             Username = user.UserName,
//             UserProfilePictureUrl = user.ProfilePictureUrl,
//             MediaUrl = story.MediaUrl,
//             CreatedAt = story.CreatedAt,
//             ExpiresAt = story.ExpiresAt,
//             ViewCount = 0,
//             HasViewed = false
//         };
//     }

//     public async Task<List<StoryDto>> GetUserStoriesAsync(Guid userId, Guid viewerId)
//     {
//         var user = await _context.Users
//             .FirstOrDefaultAsync(u => u.Id == userId);
            
//         if (user == null)
//         {
//             throw new NotFoundException($"User with ID {userId} not found");
//         }


//         var stories = await _context.Stories
//             .Where(s => s.UserId == userId && s.ExpiresAt > DateTime.UtcNow)
//             .OrderBy(s => s.CreatedAt)
//             .Select(s => new StoryDto
//             {
//                 Id = s.Id,
//                 UserId = s.UserId,
//                 Username = s.User.UserName,
//                 UserProfilePictureUrl = s.User.ProfilePictureUrl,
//                 MediaUrl = s.MediaUrl,
//                 CreatedAt = s.CreatedAt,
//                 ExpiresAt = s.ExpiresAt,
//                 ViewCount = s.Views.Count,
//                 HasViewed = s.Views.Any(v => v.ViewerId == viewerId)
//             })
//             .ToListAsync();

//         return stories;
//     }

//     public async Task<StoryDto> ViewStoryAsync(Guid storyId, Guid viewerId)
//     {
//         var story = await _context.Stories
//             .Include(s => s.User)
//             .Include(s => s.Views)
//             .FirstOrDefaultAsync(s => s.Id == storyId && s.ExpiresAt > DateTime.UtcNow);

//         if (story == null)
//         {
//             throw new NotFoundException($"Story with ID {storyId} not found or expired");
//         }


//         var existingView = await _context.StoryViews
//             .FirstOrDefaultAsync(sv => sv.StoryId == storyId && sv.ViewerId == viewerId);

//         if (existingView == null)
//         {
//             // first time see the story
//             _context.StoryViews.Add(new StoryView
//             {
//                 Id = Guid.NewGuid(),
//                 StoryId = storyId,
//                 ViewerId = viewerId,
//                 ViewedAt = DateTime.UtcNow
//             });

//             await _context.SaveChangesAsync();
//         }

//         return new StoryDto
//         {
//             Id = story.Id,
//             UserId = story.UserId,
//             Username = story.User.UserName,
//             UserProfilePictureUrl = story.User.ProfilePictureUrl,
//             MediaUrl = story.MediaUrl,
//             CreatedAt = story.CreatedAt,
//             ExpiresAt = story.ExpiresAt,
//             ViewCount = story.Views.Count + (existingView == null ? 1 : 0),
//             HasViewed = true
//         };
//     }

//     public async Task<List<StoryGroupDto>> GetStoriesFeedAsync(Guid userId)
//     {
//         var followedUserIds = await _context.Users
//             .Where(u => u.Id == userId)
//             .SelectMany(u => u.Following.Select(f => f.FollowedUserId))
//             .ToListAsync();
        
//         if (followedUserIds == null || !followedUserIds.Any())
//         {
//             return new List<StoryGroupDto>();
//         }
        
//         // Add current user to the list to see own stories
//         followedUserIds.Add(userId);

//         var usersWithStories = await _context.Users
//             .Where(u => followedUserIds.Contains(u.Id))
//             .Where(u => u.Stories.Any(s => s.ExpiresAt > DateTime.UtcNow))
//             .OrderByDescending(u => u.Id == userId) // Put current user first
//             .ThenByDescending(u => u.Stories.Max(s => s.CreatedAt)) // Then order by most recent story
//             .Select(u => new
//             {
//                 User = u,
//                 Stories = u.Stories.Where(s => s.ExpiresAt > DateTime.UtcNow).OrderBy(s => s.CreatedAt),
//                 HasUnseenStories = u.Stories.Any(s => s.ExpiresAt > DateTime.UtcNow && !s.Views.Any(v => v.ViewerId == userId))
//             })
//             .ToListAsync();

//         var storyGroups = usersWithStories.Select(group => new StoryGroupDto
//         {
//             UserId = group.User.Id,
//             Username = group.User.UserName,
//             ProfilePictureUrl = group.User.ProfilePictureUrl,
//             HasUnseenStories = group.HasUnseenStories,
//             Stories = group.Stories.Select(s => new StoryDto
//             {
//                 Id = s.Id,
//                 UserId = s.UserId,
//                 Username = group.User.UserName,
//                 UserProfilePictureUrl = group.User.ProfilePictureUrl,
//                 MediaUrl = s.MediaUrl,
//                 CreatedAt = s.CreatedAt,
//                 ExpiresAt = s.ExpiresAt,
//                 ViewCount = s.Views.Count,
//                 HasViewed = s.Views.Any(v => v.ViewerId == userId)
//             }).ToList()
//         }).ToList();

//         return storyGroups;
//     }

//     public async Task<bool> DeleteStoryAsync(Guid storyId, Guid userId)
//     {
//         var story = await _context.Stories
//             .FirstOrDefaultAsync(s => s.Id == storyId && s.UserId == userId);

//         if (story == null)
//         {
//             throw new NotFoundException($"Story with ID {storyId} not found or you don't have permission to delete it");
//         }

//         // Delete media files
//         if (!string.IsNullOrEmpty(story.MediaUrl))
//         {
//             await _storageService.DeleteFileAsync(story.MediaUrl);
//         }

//         if (!string.IsNullOrEmpty(story.ThumbnailUrl))
//         {
//             await _storageService.DeleteFileAsync(story.ThumbnailUrl);
//         }

//         _context.Stories.Remove(story);
//         await _context.SaveChangesAsync();

//         return true;
//     }

//     public async Task<bool> CleanExpiredStoriesAsync()
//     {
//         // This method will called by a background service scheduler
//         var expiredStories = await _context.Stories
//             .Where(s => s.ExpiresAt < DateTime.UtcNow)
//             .ToListAsync();

//         foreach (var story in expiredStories)
//         {
//             // Delete media files
//             if (!string.IsNullOrEmpty(story.MediaUrl))
//             {
//                 await _storageService.DeleteFileAsync(story.MediaUrl);
//             }

//             if (!string.IsNullOrEmpty(story.ThumbnailUrl))
//             {
//                 await _storageService.DeleteFileAsync(story.ThumbnailUrl);
//             }
//         }

//         _context.Stories.RemoveRange(expiredStories);
//         await _context.SaveChangesAsync();

//         _logger.LogInformation($"Cleaned {expiredStories.Count} expired stories");
//         return true;
//     }
// }