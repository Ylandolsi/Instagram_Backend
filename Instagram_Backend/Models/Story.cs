// using System;
// using System.Collections.Generic;

// namespace Instagram_Backend.Models ; 
// public class Story
// {
//     public Guid Id { get; set; }
//     public Guid UserId { get; set; }
//     public User User { get; set; }
//     public string MediaUrl { get; set; }
//     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
//     public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddHours(24);
//     public ICollection<StoryView> Views { get; set; } = new List<StoryView>();
//     public bool IsActive => DateTime.UtcNow < ExpiresAt;
// }