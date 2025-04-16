using Instagram_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Backend.Database;

public static class DataSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        // Fixed dates for seeding
        var baseDate = new DateTime(2025, 3, 15, 0, 0, 0, DateTimeKind.Utc);
        var createdAt = baseDate; 
        // Password123!
        var passwordHash = "AQAAAAIAAYagAAAAEG9Yh999XbrReKfYRF6NzknIDvSmTjBuDq4KQkfqZweYlubTSIOeVLFmxSD3tar1IA==";
        
        // Generate IDs upfront to maintain relationships
        // User IDs
        var johnId = Guid.NewGuid();
        var janeId = Guid.NewGuid();
        var alexId = Guid.NewGuid();
        var emilyId = Guid.NewGuid();
        var michaelId = Guid.NewGuid();
        var sophiaId = Guid.NewGuid();
        var davidId = Guid.NewGuid();
        var oliviaId = Guid.NewGuid();
        
        // Create users
        var users = new List<User>
        {
            new User
            {
                Id = johnId,
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Email = "john@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "JOHN@EXAMPLE.COM",
                NormalizedUserName = "JOHNDOE", 
                SecurityStamp = Guid.NewGuid().ToString(),
                ProfilePictureUrl = "https://randomuser.me/api/portraits/men/1.jpg",
                Bio = "Photography enthusiast and traveler"
            },
            new User
            {
                Id = janeId,
                FirstName = "Jane",
                LastName = "Smith",
                UserName = "janesmith",
                Email = "jane@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "JANE@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "JANESMITH",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/women/1.jpg",
                Bio = "Food blogger | Travel lover"
            },
            new User
            {
                Id = alexId,
                FirstName = "Alex",
                LastName = "Johnson",
                UserName = "alexj",
                Email = "alex@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "ALEX@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "ALEXJ",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/men/2.jpg",
                Bio = "Software developer and coffee addict"
            },
            new User
            {
                Id = emilyId,
                FirstName = "Emily",
                LastName = "Chen",
                UserName = "emilyc",
                Email = "emily@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "EMILY@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "EMILYC",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/women/2.jpg",
                Bio = "Digital artist and designer"
            },
            new User
            {
                Id = michaelId,
                FirstName = "Michael",
                LastName = "Taylor",
                UserName = "michaelt",
                Email = "michael@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "MICHAEL@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "MICHAELT",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/men/3.jpg",
                Bio = "Fitness enthusiast and nutrition coach"
            },
            new User
            {
                Id = sophiaId,
                FirstName = "Sophia",
                LastName = "Garcia",
                UserName = "sophiag",
                Email = "sophia@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "SOPHIA@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "SOPHIAG",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/women/3.jpg",
                Bio = "Fashion designer and trend spotter"
            },
            new User
            {
                Id = davidId,
                FirstName = "David",
                LastName = "Wilson",
                UserName = "davidw",
                Email = "david@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "DAVID@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "DAVIDW",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/men/4.jpg",
                Bio = "Chef and food photographer"
            },
            new User
            {
                Id = oliviaId,
                FirstName = "Olivia",
                LastName = "Martinez",
                UserName = "oliviam",
                Email = "olivia@example.com",
                EmailConfirmed = true,
                PasswordHash = passwordHash,
                NormalizedEmail = "OLIVIA@EXAMPLE.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedUserName = "OLIVIAM",
                ProfilePictureUrl = "https://randomuser.me/api/portraits/women/4.jpg",
                Bio = "Travel blogger and outdoor enthusiast"
            }
        };

        // Seed users
        modelBuilder.Entity<User>().HasData(users);

        // Generate post IDs
        var johnPost1Id = Guid.NewGuid();
        var janePost1Id = Guid.NewGuid();
        var janePost2Id = Guid.NewGuid();
        var johnPost2Id = Guid.NewGuid();
        var johnPost3Id = Guid.NewGuid();
        var johnPost4Id = Guid.NewGuid();
        var johnPost5Id = Guid.NewGuid();
        var johnPost6Id = Guid.NewGuid();
        var alexPost1Id = Guid.NewGuid();
        var janePost3Id = Guid.NewGuid();
        var alexPost2Id = Guid.NewGuid();
        var alexPost3Id = Guid.NewGuid();
        var alexPost4Id = Guid.NewGuid();
        var alexPost5Id = Guid.NewGuid();
        var alexPost6Id = Guid.NewGuid();
        var emilyPost1Id = Guid.NewGuid();
        var emilyPost2Id = Guid.NewGuid();
        var michaelPost1Id = Guid.NewGuid();
        var michaelPost2Id = Guid.NewGuid();
        var sophiaPost1Id = Guid.NewGuid();
        var davidPost1Id = Guid.NewGuid();
        var oliviaPost1Id = Guid.NewGuid();

        // Create posts
        var posts = new List<Post>
        {
            new Post
            {
                Id = johnPost1Id,
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = createdAt,
                UserId = johnId,
            },
            new Post
            {
                Id = janePost1Id,
                Caption = "My homemade pasta recipe 🍝",
                CreatedAt = createdAt,
                UserId = janeId,
            },
            new Post
            {
                Id = janePost2Id,
                Caption = "My homemade pasta recipe 🍝",
                CreatedAt = createdAt,
                UserId = janeId,
            },
            new Post
            {
                Id = johnPost2Id,
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = createdAt,
                UserId = johnId,
            },
            new Post
            {
                Id = johnPost3Id,
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = createdAt,
                UserId = johnId,
            },
            new Post
            {
                Id = johnPost4Id,
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = createdAt,
                UserId = johnId,
            },
            new Post
            {
                Id = johnPost5Id,
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = createdAt,
                UserId = johnId,
            },
            new Post
            {
                Id = johnPost6Id,
                Caption = "Beautiful sunset at the beach!",
                CreatedAt = createdAt,
                UserId = johnId,
            },
            new Post
            {
                Id = alexPost1Id,
                Caption = "New coding setup complete",
                CreatedAt = createdAt,
                UserId = alexId,
                CommentCount = 4,
                LikeCount = 28
            },
            new Post
            {
                Id = janePost3Id,
                Caption = "My homemade pasta recipe 🍝",
                CreatedAt = createdAt,
                UserId = janeId,
                CommentCount = 3,
                LikeCount = 42
            },
            new Post
            {
                Id = alexPost2Id,
                Caption = "New coding setup complete",
                CreatedAt = createdAt,
                UserId = alexId,
                CommentCount = 4,
                LikeCount = 28
            },
            new Post
            {
                Id = alexPost3Id,
                Caption = "New coding setup complete",
                CreatedAt = createdAt,
                UserId = alexId,
                CommentCount = 4,
                LikeCount = 28
            },
            new Post
            {
                Id = alexPost4Id,
                Caption = "New coding setup complete",
                CreatedAt = createdAt,
                UserId = alexId,
            },
            new Post
            {
                Id = alexPost5Id,
                Caption = "New coding setup complete",
                CreatedAt = createdAt,
                UserId = alexId,
            },
            new Post
            {
                Id = alexPost6Id,
                Caption = "New coding setup complete",
                CreatedAt = createdAt,
                UserId = alexId,
            },
            // New user posts
            new Post
            {
                Id = emilyPost1Id,
                Caption = "My latest digital art piece - cyberpunk cityscape 🌆",
                CreatedAt = createdAt,
                UserId = emilyId,
            },
            new Post
            {
                Id = emilyPost2Id,
                Caption = "New plant baby added to my collection! 🌱",
                CreatedAt = createdAt.AddDays(-2),
                UserId = emilyId,
            },
            new Post
            {
                Id = michaelPost1Id,
                Caption = "Today's workout: 5 mile run and full-body HIIT 💪",
                CreatedAt = createdAt.AddDays(-1),
                UserId = michaelId,
            },
            new Post
            {
                Id = michaelPost2Id,
                Caption = "Meal prep for the week! Healthy eating doesn't have to be boring 🥗",
                CreatedAt = createdAt.AddDays(-4),
                UserId = michaelId,
            },
            new Post
            {
                Id = sophiaPost1Id,
                Caption = "My latest fashion collection inspired by Mediterranean summers ☀️",
                CreatedAt = createdAt.AddDays(-3),
                UserId = sophiaId,
            },
            new Post
            {
                Id = davidPost1Id,
                Caption = "Homemade sourdough pizza with fresh basil and buffalo mozzarella 🍕",
                CreatedAt = createdAt.AddDays(-2),
                UserId = davidId,
            },
            new Post
            {
                Id = oliviaPost1Id,
                Caption = "Sunrise hike at Mount Rainier. Worth waking up at 4am! 🏔️",
                CreatedAt = createdAt.AddDays(-5),
                UserId = oliviaId,
            }
        };

        modelBuilder.Entity<Post>().HasData(posts);

        // Generate image IDs
        var johnPost1Image1Id = Guid.NewGuid();
        var janePost1Image1Id = Guid.NewGuid();
        var janePost1Image2Id = Guid.NewGuid();
        var janePost2Image1Id = Guid.NewGuid();
        
        // Create images
        var images = new List<Image>
        {
            new Image
            {
                Id = johnPost1Image1Id,
                Url = "https://picsum.photos/id/1/800/800",
                Order = 1,
                PostId = johnPost1Id
            },
            new Image
            {
                Id = janePost1Image1Id,
                Url = "https://picsum.photos/id/2/800/800",
                Order = 1,
                PostId = janePost1Id
            },
            new Image
            {
                Id = janePost1Image2Id,
                Url = "https://picsum.photos/id/3/800/800",
                Order = 2,
                PostId = janePost1Id
            },
            new Image
            {
                Id = janePost2Image1Id,
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = janePost2Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = johnPost2Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = johnPost3Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 2,
                PostId = johnPost3Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 3,
                PostId = johnPost3Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 4,
                PostId = johnPost3Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = johnPost4Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = johnPost5Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = johnPost6Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = alexPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = janePost3Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = alexPost2Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = alexPost3Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = alexPost4Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 2,
                PostId = alexPost4Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = alexPost5Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 2,
                PostId = alexPost5Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/4/800/800",
                Order = 1,
                PostId = alexPost6Id
            },
            // Images for new posts
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/10/800/800",
                Order = 1,
                PostId = emilyPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/11/800/800",
                Order = 1,
                PostId = emilyPost2Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/12/800/800",
                Order = 1,
                PostId = michaelPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/13/800/800",
                Order = 1,
                PostId = michaelPost2Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/14/800/800",
                Order = 2,
                PostId = michaelPost2Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/15/800/800",
                Order = 1,
                PostId = sophiaPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/16/800/800",
                Order = 2,
                PostId = sophiaPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/17/800/800",
                Order = 3,
                PostId = sophiaPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/18/800/800",
                Order = 1,
                PostId = davidPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/19/800/800",
                Order = 1,
                PostId = oliviaPost1Id
            },
            new Image
            {
                Id = Guid.NewGuid(),
                Url = "https://picsum.photos/id/20/800/800",
                Order = 2,
                PostId = oliviaPost1Id
            }
        };

        modelBuilder.Entity<Image>().HasData(images);

        // Generate comment IDs
        var janeCommentOnJohnPost1Id = Guid.NewGuid();
        var johnReplyToJaneId = Guid.NewGuid();
        var alexCommentOnJanePost1Id = Guid.NewGuid();
        var johnCommentOnJanePost1Id = Guid.NewGuid();
        var janeReplyToJohnId = Guid.NewGuid();
        var johnCommentOnJanePost2Id = Guid.NewGuid();
        var alexReplyToJohnId = Guid.NewGuid();
        var johnCommentOnEmilyPost1Id = Guid.NewGuid();
        var emilyReplyToJohnId = Guid.NewGuid();
        var alexCommentOnMichaelPost1Id = Guid.NewGuid();
        var michaelReplyToAlexId = Guid.NewGuid();
        var janeCommentOnSophiaPost1Id = Guid.NewGuid();
        var sophiaReplyToJaneId = Guid.NewGuid();
        var oliviaCommentOnDavidPost1Id = Guid.NewGuid();
        var davidReplyToOliviaId = Guid.NewGuid();

        // Create comments
        var comments = new List<Comment>
        {
            new Comment
            {
                Id = janeCommentOnJohnPost1Id,
                Content = "Amazing view!",
                CreatedAt = createdAt,
                UserId = janeId,
                PostId = johnPost1Id,
                LikeCount = 3,
                ReplyCount = 1
            },
            new Comment
            {
                Id = johnReplyToJaneId,
                Content = "Thanks! It was incredible.",
                CreatedAt = createdAt,
                UserId = johnId,
                PostId = johnPost1Id,
                ParentCommentId = janeCommentOnJohnPost1Id,
                LikeCount = 1,
                ReplyCount = 0
            },
            new Comment
            {
                Id = alexCommentOnJanePost1Id,
                Content = "This looks delicious!",
                CreatedAt = createdAt,
                UserId = alexId,
                PostId = janePost1Id,
                LikeCount = 4,
                ReplyCount = 1
            },
            new Comment
            {
                Id = johnCommentOnJanePost1Id,
                Content = "Can you share the recipe?",
                CreatedAt = createdAt,
                UserId = johnId,
                PostId = janePost1Id,
                LikeCount = 0,
                ReplyCount = 1
            },
            new Comment
            {
                Id = janeReplyToJohnId,
                Content = "Sure, I'll DM you!",
                CreatedAt = createdAt,
                UserId = janeId,
                PostId = janePost1Id,
                ParentCommentId = johnCommentOnJanePost1Id,
                LikeCount = 1,
                ReplyCount = 0
            },
            new Comment
            {
                Id = johnCommentOnJanePost2Id,
                Content = "Nice setup! What monitor is that?",
                CreatedAt = createdAt,
                UserId = johnId,
                PostId = janePost2Id,
                LikeCount = 1,
                ReplyCount = 1
            },
            new Comment
            {
                Id = alexReplyToJohnId,
                Content = "It's an LG 34\" ultrawide",
                CreatedAt = createdAt,
                UserId = alexId,
                PostId = janePost2Id,
                ParentCommentId = johnCommentOnJanePost2Id,
                LikeCount = 0,
                ReplyCount = 0
            },
            // New comments
            new Comment
            {
                Id = johnCommentOnEmilyPost1Id,
                Content = "This is incredible! Love the neon colors!",
                CreatedAt = createdAt,
                UserId = johnId,
                PostId = emilyPost1Id,
                LikeCount = 2,
                ReplyCount = 1
            },
            new Comment
            {
                Id = emilyReplyToJohnId,
                Content = "Thank you so much! Took me almost a week to finish.",
                CreatedAt = createdAt.AddHours(1),
                UserId = emilyId,
                PostId = emilyPost1Id,
                ParentCommentId = johnCommentOnEmilyPost1Id,
                LikeCount = 1,
                ReplyCount = 0
            },
            new Comment
            {
                Id = alexCommentOnMichaelPost1Id,
                Content = "What's your favorite HIIT exercise?",
                CreatedAt = createdAt,
                UserId = alexId,
                PostId = michaelPost1Id,
                LikeCount = 1,
                ReplyCount = 1
            },
            new Comment
            {
                Id = michaelReplyToAlexId,
                Content = "Definitely burpees - they're brutal but effective!",
                CreatedAt = createdAt.AddHours(2),
                UserId = michaelId,
                PostId = michaelPost1Id,
                ParentCommentId = alexCommentOnMichaelPost1Id,
                LikeCount = 2,
                ReplyCount = 0
            },
            new Comment
            {
                Id = janeCommentOnSophiaPost1Id,
                Content = "These designs are stunning! Will they be available in your online shop?",
                CreatedAt = createdAt,
                UserId = janeId,
                PostId = sophiaPost1Id,
                LikeCount = 3,
                ReplyCount = 1
            },
            new Comment
            {
                Id = sophiaReplyToJaneId,
                Content = "Yes! They'll be available next month. I'll share a discount code soon!",
                CreatedAt = createdAt.AddHours(3),
                UserId = sophiaId,
                PostId = sophiaPost1Id,
                ParentCommentId = janeCommentOnSophiaPost1Id,
                LikeCount = 1,
                ReplyCount = 0
            },
            new Comment
            {
                Id = oliviaCommentOnDavidPost1Id,
                Content = "That crust looks perfect! Would love to see your sourdough recipe.",
                CreatedAt = createdAt,
                UserId = oliviaId,
                PostId = davidPost1Id,
                LikeCount = 2,
                ReplyCount = 1
            },
            new Comment
            {
                Id = davidReplyToOliviaId,
                Content = "I'll share it in my next post! It's all about the 24-hour fermentation.",
                CreatedAt = createdAt.AddHours(1),
                UserId = davidId,
                PostId = davidPost1Id,
                ParentCommentId = oliviaCommentOnDavidPost1Id,
                LikeCount = 1,
                ReplyCount = 0
            }
        };

        modelBuilder.Entity<Comment>().HasData(comments);

        // Create likes
        var likes = new List<Like>
        {
            // Likes for posts
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = johnPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = alexId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = johnPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = janePost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = alexId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = janePost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = janePost2Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = janePost2Id,
            },

            // Likes for comments
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                Type = LikeType.Comment,
                CreatedAt = createdAt,
                CommentId = janeCommentOnJohnPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = alexId,
                Type = LikeType.Comment,
                CreatedAt = createdAt,
                CommentId = janeCommentOnJohnPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                Type = LikeType.Comment,
                CreatedAt = createdAt,
                CommentId = johnReplyToJaneId,
            },
            // Likes for new posts
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = emilyPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = emilyPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = alexId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = michaelPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = emilyId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = michaelPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                Type = LikeType.Post,
                CreatedAt = createdAt,
                PostId = sophiaPost1Id,
            },
            // Likes for new comments
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = emilyId,
                Type = LikeType.Comment,
                CreatedAt = createdAt,
                CommentId = johnCommentOnEmilyPost1Id,
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = alexId,
                Type = LikeType.Comment,
                CreatedAt = createdAt,
                CommentId = janeCommentOnSophiaPost1Id,
            }
        };

        modelBuilder.Entity<Like>().HasData(likes);

        // Create notifications
        var notifications = new List<Notification>
        {
            // Like notifications
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                ActorId = janeId,
                Type = NotificationType.Like,
                Content = "liked your post",
                PostId = johnPost1Id,
                CreatedAt = createdAt,
                IsRead = true
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                ActorId = alexId,
                Type = NotificationType.Like,
                Content = "liked your post",
                PostId = johnPost1Id,
                CreatedAt = createdAt,
                IsRead = true
            },
            
            // Comment notifications
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = johnId,
                ActorId = janeId,
                Type = NotificationType.Comment,
                Content = "commented on your post",
                PostId = johnPost1Id,
                CommentId = janeCommentOnJohnPost1Id,
                CreatedAt = createdAt,
                IsRead = true
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                ActorId = johnId,
                Type = NotificationType.Comment,
                Content = "replied to your comment",
                PostId = johnPost1Id,
                CommentId = johnReplyToJaneId,
                CreatedAt = createdAt,
                IsRead = true
            },
            
            // Follow notifications
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = janeId,
                ActorId = johnId,
                Type = NotificationType.Follow,
                Content = "started following you",
                CreatedAt = createdAt,
                IsRead = true
            },
            // New notifications
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = emilyId,
                ActorId = johnId,
                Type = NotificationType.Like,
                Content = "liked your post",
                PostId = emilyPost1Id,
                CreatedAt = createdAt,
                IsRead = false
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = emilyId,
                ActorId = janeId,
                Type = NotificationType.Like,
                Content = "liked your post",
                PostId = emilyPost1Id,
                CreatedAt = createdAt,
                IsRead = false
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = emilyId,
                ActorId = johnId,
                Type = NotificationType.Comment,
                Content = "commented on your post",
                PostId = emilyPost1Id,
                CommentId = johnCommentOnEmilyPost1Id,
                CreatedAt = createdAt,
                IsRead = true
            },
            new Notification
            {
                Id = Guid.NewGuid(),
                UserId = michaelId,
                ActorId = alexId,
                Type = NotificationType.Comment,
                Content = "commented on your post",
                PostId = michaelPost1Id,
                CommentId = alexCommentOnMichaelPost1Id,
                CreatedAt = createdAt,
                IsRead = true
            }
        };

        modelBuilder.Entity<Notification>().HasData(notifications);

        // Create user followers
        var userFollowers = new List<UserFollower>
        {
            // Original relationships
            new UserFollower { FollowerId = janeId, FollowingId = johnId },
            new UserFollower { FollowerId = alexId, FollowingId = johnId },
            new UserFollower { FollowerId = johnId, FollowingId = janeId },
            new UserFollower { FollowerId = johnId, FollowingId = alexId },
            new UserFollower { FollowerId = janeId, FollowingId = alexId },
            new UserFollower { FollowerId = alexId, FollowingId = janeId },
            
            // New relationships
            new UserFollower { FollowerId = emilyId, FollowingId = johnId },
            new UserFollower { FollowerId = johnId, FollowingId = emilyId },
            new UserFollower { FollowerId = emilyId, FollowingId = janeId },
            new UserFollower { FollowerId = janeId, FollowingId = emilyId },
            new UserFollower { FollowerId = michaelId, FollowingId = alexId },
            new UserFollower { FollowerId = alexId, FollowingId = michaelId },
            new UserFollower { FollowerId = michaelId, FollowingId = emilyId },
            new UserFollower { FollowerId = sophiaId, FollowingId = janeId },
            new UserFollower { FollowerId = janeId, FollowingId = sophiaId },
            new UserFollower { FollowerId = sophiaId, FollowingId = emilyId },
            new UserFollower { FollowerId = davidId, FollowingId = johnId },
            new UserFollower { FollowerId = davidId, FollowingId = sophiaId },
            new UserFollower { FollowerId = oliviaId, FollowingId = davidId },
            new UserFollower { FollowerId = davidId, FollowingId = oliviaId },
            new UserFollower { FollowerId = oliviaId, FollowingId = sophiaId },
            new UserFollower { FollowerId = michaelId, FollowingId = davidId },
            new UserFollower { FollowerId = oliviaId, FollowingId = emilyId },
            new UserFollower { FollowerId = sophiaId, FollowingId = oliviaId },
        };
        
        modelBuilder.Entity<UserFollower>().HasData(userFollowers);
    }
}