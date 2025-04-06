
namespace Instagram_Backend.Mappers;
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

    public static CommentDto MapCommentToDto(Comment comment, Guid currentUserId)
    {
        return new CommentDto
        {
            Id = comment.Id,
            PostId = comment.PostId,
            User = MapUserToDto(comment.User),
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            LikeCount = comment.Likes.Count(l => l.UserId == currentUserId),
            IsLikedByCurrentUser = comment.Likes.Any(l => l.UserId == currentUserId),
            ParentCommentId = comment.ParentCommentId,
            ReplyCount = comment.Replies.Count
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


    public static PostDto MapPostToDto(Post post, Guid currentUserId)
    {
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
            CommentCount = post.Comments?.Count ?? 0,
            LikeCount = post.Likes?.Count ?? 0,
            IsLikedByCurrentUser = post.Likes?.Any(l => l.UserId == currentUserId) ?? false,
        };
    }



}