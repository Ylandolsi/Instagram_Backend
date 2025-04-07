
namespace Instagram_Backend.Mappers;

using Instagram_Backend.Database;
using Instagram_Backend.Dtos;
using Instagram_Backend.Dtos.Comments;
using Instagram_Backend.Dtos.Posts;
using Instagram_Backend.Models;

public static class MapperDto
{

    public static UserDto MapUserToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName ?? string.Empty,
            ProfilePictureUrl = user.ProfilePictureUrl ?? string.Empty
        };
    }

    public static ImageDto MapImageToDto(Image image)
    {
        return new ImageDto
        {
            Id = image.Id,
            Url = image.Url,
            PostId = image.PostId,
            Order = image.Order
        };
    }
    public static CommentDto MapCommentToDto(Comment comment, Guid currentUserId , ApplicationDbContext context)
    {
        bool isLikedByCurrentUser = false;
    
        if (context != null)
        {
            isLikedByCurrentUser = context.Likes.Any(l => 
                l.CommentId == comment.Id && 
                l.UserId == currentUserId && 
                l.Type == LikeType.Comment);
        }
        return new CommentDto
        {
            Id = comment.Id,
            PostId = comment.PostId,
            User = MapUserToDto(comment.User),
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            LikeCount = comment.LikeCount , 
            ParentCommentId = comment.ParentCommentId,
            ReplyCount = comment.ReplyCount,
            IsLikedByCurrentUser = isLikedByCurrentUser,
        };
    }


    public static PostDto MapPostToDto(Post post, Guid currentUserId , ApplicationDbContext context )
    {
        bool isLikedByCurrentUser = false;
    
        if (context != null)
        {
            isLikedByCurrentUser = context.Likes.Any(l => 
                l.PostId == post.Id && 
                l.UserId == currentUserId && 
                l.Type == LikeType.Post);
        }
        return new PostDto
        {
            Id = post.Id,
            User = post.User != null ? MapUserToDto(post.User) : null,
            Caption = post.Caption,
            Images = post.Images?
                .OrderBy(i => i.Order)
                .Select(i => MapImageToDto(i))
                .ToList() ?? new List<ImageDto>(),
            CreatedAt = post.CreatedAt,
            CommentCount = post.CommentCount,
            LikeCount = post.LikeCount,
            IsLikedByCurrentUser = isLikedByCurrentUser,

        };
    }



}