using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Database;

public static class DataSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        // Fixed dates for seeding
        var baseDate = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc);
        
        // Create users
        var users = new List<User>
        {
            new User
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "john@example.com",
                EmailConfirmed = true,
                NormalizedEmail = "JOHN@EXAMPLE.COM",
                NormalizedUserName = "JOHNDOE",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/men/1.jpg",
                Bio = "Photography enthusiast and traveler"
            },
            new User
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                FirstName = "Jane",
                LastName = "Smith",
                UserName = "janesmith",
                Email = "jane@example.com",
                EmailConfirmed = true,
                NormalizedEmail = "JANE@EXAMPLE.COM",
                NormalizedUserName = "JANESMITH",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/women/1.jpg",
                Bio = "Food blogger | Travel lover"
            },
            new User
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                FirstName = "Alex",
                LastName = "Johnson",
                UserName = "alexj",
                Email = "alex@example.com",
                EmailConfirmed = true,
                NormalizedEmail = "ALEX@EXAMPLE.COM",
                NormalizedUserName = "ALEXJ",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/men/2.jpg",
                Bio = "Software developer and coffee addict"
            }
        };

        // Seed users
        modelBuilder.Entity<User>().HasData(users);

        // Create posts
        var posts = new List<Post>
        {
            new Post
            {
                Id = Guid.Parse("a1111111-a111-a111-a111-a11111111111"),
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = baseDate.AddDays(-10),
                UserId = users[0].Id,
                CommentCount = 2,
                LikeCount = 15
            },
            new Post
            {
                Id = Guid.Parse("a2222222-a222-a222-a222-a22222222222"),
                Caption = "My homemade pasta recipe 🍝",
                CreatedAt = baseDate.AddDays(-5),
                UserId = users[1].Id,
                CommentCount = 3,
                LikeCount = 42
            },
            new Post
            {
                Id = Guid.Parse("a3333333-a333-a333-a333-a33333333333"),
                Caption = "New coding setup complete",
                CreatedAt = baseDate.AddDays(-2),
                UserId = users[2].Id,
                CommentCount = 4,
                LikeCount = 28
            }
        };

        // Seed posts
        modelBuilder.Entity<Post>().HasData(posts);

        // Create images for posts
        var images = new List<Image>
        {
            new Image
            {
                Id = Guid.Parse("b1111111-b111-b111-b111-b11111111111"),
                Url = "https://picsum.photos/id/1/800/800",
                Order = 1,
                PostId = posts[0].Id
            },
            new Image
            {
                Id = Guid.Parse("b2222222-b222-b222-b222-b22222222222"),
                Url = "https://picsum.photos/id/2/800/800",
                Order = 1,
                PostId = posts[1].Id
            },
            new Image
            {
                Id = Guid.Parse("b3333333-b333-b333-b333-b33333333333"),
                Url = "https://picsum.photos/id/3/800/800",
                Order = 2,
                PostId = posts[1].Id
            },
            new Image
            {
                Id = Guid.Parse("b4444444-b444-b444-b444-b44444444444"),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = posts[2].Id
            }
        };

        // Seed images
        modelBuilder.Entity<Image>().HasData(images);

        // Create comments
        var comments = new List<Comment>
        {
            new Comment
            {
                Id = Guid.Parse("c1111111-c111-c111-c111-c11111111111"),
                Content = "Amazing view!",
                CreatedAt = baseDate.AddDays(-9),
                UserId = users[1].Id,
                PostId = posts[0].Id,
                LikeCount = 3,
                ReplyCount = 1
            },
            new Comment
            {
                Id = Guid.Parse("c2222222-c222-c222-c222-c22222222222"),
                Content = "Thanks! It was incredible.",
                CreatedAt = baseDate.AddDays(-9).AddHours(2),
                UserId = users[0].Id,
                PostId = posts[0].Id,
                ParentCommentId = Guid.Parse("c1111111-c111-c111-c111-c11111111111"),
                LikeCount = 1,
                ReplyCount = 0
            },
            new Comment
            {
                Id = Guid.Parse("c3333333-c333-c333-c333-c33333333333"),
                Content = "This looks delicious!",
                CreatedAt = baseDate.AddDays(-4),
                UserId = users[2].Id,
                PostId = posts[1].Id,
                LikeCount = 4,
                ReplyCount = 1
            },
            new Comment
            {
                Id = Guid.Parse("c4444444-c444-c444-c444-c44444444444"),
                Content = "Can you share the recipe?",
                CreatedAt = baseDate.AddDays(-4).AddHours(1),
                UserId = users[0].Id,
                PostId = posts[1].Id,
                LikeCount = 0,
                ReplyCount = 1
            },
            new Comment
            {
                Id = Guid.Parse("c5555555-c555-c555-c555-c55555555555"),
                Content = "Sure, I'll DM you!",
                CreatedAt = baseDate.AddDays(-4).AddHours(3),
                UserId = users[1].Id,
                PostId = posts[1].Id,
                ParentCommentId = Guid.Parse("c4444444-c444-c444-c444-c44444444444"),
                LikeCount = 1,
                ReplyCount = 0
            },
            new Comment
            {
                Id = Guid.Parse("c6666666-c666-c666-c666-c66666666666"),
                Content = "Nice setup! What monitor is that?",
                CreatedAt = baseDate.AddDays(-1),
                UserId = users[0].Id,
                PostId = posts[2].Id,
                LikeCount = 1,
                ReplyCount = 1
            },
            new Comment
            {
                Id = Guid.Parse("c7777777-c777-c777-c777-c77777777777"),
                Content = "It's an LG 34\" ultrawide",
                CreatedAt = baseDate.AddHours(-20),
                UserId = users[2].Id,
                PostId = posts[2].Id,
                ParentCommentId = Guid.Parse("c6666666-c666-c666-c666-c66666666666"),
                LikeCount = 0,
                ReplyCount = 0
            }
        };

        // Seed comments
        modelBuilder.Entity<Comment>().HasData(comments);

        // Create likes
        var likes = new List<Like>
        {
            // Likes for posts
            new Like
            {
                Id = Guid.Parse("d1111111-d111-d111-d111-d11111111111"),
                UserId = users[1].Id,
                Type = LikeType.Post,
                PostId = posts[0].Id,
                CreatedAt = baseDate.AddDays(-9)
            },
            new Like
            {
                Id = Guid.Parse("d2222222-d222-d222-d222-d22222222222"),
                UserId = users[2].Id,
                Type = LikeType.Post,
                PostId = posts[0].Id,
                CreatedAt = baseDate.AddDays(-8)
            },
            new Like
            {
                Id = Guid.Parse("d3333333-d333-d333-d333-d33333333333"),
                UserId = users[0].Id,
                Type = LikeType.Post,
                PostId = posts[1].Id,
                CreatedAt = baseDate.AddDays(-5)
            },
            new Like
            {
                Id = Guid.Parse("d4444444-d444-d444-d444-d44444444444"),
                UserId = users[2].Id,
                Type = LikeType.Post,
                PostId = posts[1].Id,
                CreatedAt = baseDate.AddDays(-4)
            },
            new Like
            {
                Id = Guid.Parse("d5555555-d555-d555-d555-d55555555555"),
                UserId = users[0].Id,
                Type = LikeType.Post,
                PostId = posts[2].Id,
                CreatedAt = baseDate.AddDays(-1)
            },
            new Like
            {
                Id = Guid.Parse("d6666666-d666-d666-d666-d66666666666"),
                UserId = users[1].Id,
                Type = LikeType.Post,
                PostId = posts[2].Id,
                CreatedAt = baseDate.AddHours(-12)
            },

            // Likes for comments
            new Like
            {
                Id = Guid.Parse("d7777777-d777-d777-d777-d77777777777"),
                UserId = users[0].Id,
                Type = LikeType.Comment,
                CommentId = comments[0].Id,
                CreatedAt = baseDate.AddDays(-8)
            },
            new Like
            {
                Id = Guid.Parse("d8888888-d888-d888-d888-d88888888888"),
                UserId = users[2].Id,
                Type = LikeType.Comment,
                CommentId = comments[0].Id,
                CreatedAt = baseDate.AddDays(-7)
            },
            new Like
            {
                Id = Guid.Parse("d9999999-d999-d999-d999-d99999999999"),
                UserId = users[1].Id,
                Type = LikeType.Comment,
                CommentId = comments[1].Id,
                CreatedAt = baseDate.AddDays(-8)
            }
        };

        // Seed likes
        modelBuilder.Entity<Like>().HasData(likes);

        // Create notifications
        var notifications = new List<Notification>
        {
            // Like notifications
            new Notification
            {
                Id = Guid.Parse("e1111111-e111-e111-e111-e11111111111"),
                UserId = users[0].Id,
                ActorId = users[1].Id,
                Type = NotificationType.Like,
                Content = "liked your post",
                PostId = posts[0].Id,
                CreatedAt = baseDate.AddDays(-9),
                IsRead = true
            },
            new Notification
            {
                Id = Guid.Parse("e2222222-e222-e222-e222-e22222222222"),
                UserId = users[0].Id,
                ActorId = users[2].Id,
                Type = NotificationType.Like,
                Content = "liked your post",
                PostId = posts[0].Id,
                CreatedAt = baseDate.AddDays(-8),
                IsRead = true
            },
            
            // Comment notifications
            new Notification
            {
                Id = Guid.Parse("e3333333-e333-e333-e333-e33333333333"),
                UserId = users[0].Id,
                ActorId = users[1].Id,
                Type = NotificationType.Comment,
                Content = "commented on your post",
                PostId = posts[0].Id,
                CommentId = comments[0].Id,
                CreatedAt = baseDate.AddDays(-9),
                IsRead = true
            },
            new Notification
            {
                Id = Guid.Parse("e4444444-e444-e444-e444-e44444444444"),
                UserId = users[1].Id,
                ActorId = users[0].Id,
                Type = NotificationType.Comment,
                Content = "replied to your comment",
                PostId = posts[0].Id,
                CommentId = comments[1].Id,
                CreatedAt = baseDate.AddDays(-9).AddHours(2),
                IsRead = true
            },
            
            // Follow notifications
            new Notification
            {
                Id = Guid.Parse("e5555555-e555-e555-e555-e55555555555"),
                UserId = users[1].Id,
                ActorId = users[0].Id,
                Type = NotificationType.Follow,
                Content = "started following you",
                CreatedAt = baseDate.AddDays(-15),
                IsRead = true
            },
            new Notification
            {
                Id = Guid.Parse("e6666666-e666-e666-e666-e66666666666"),
                UserId = users[2].Id,
                ActorId = users[0].Id,
                Type = NotificationType.Follow,
                Content = "started following you",
                CreatedAt = baseDate.AddDays(-14),
                IsRead = false
            }
        };

        // Seed notifications
        modelBuilder.Entity<Notification>().HasData(notifications);
        


    }
}