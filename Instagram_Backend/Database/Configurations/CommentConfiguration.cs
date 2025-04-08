using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram_Backend.Database.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id); 
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Content).IsRequired().HasMaxLength(500);
        builder.Property(c => c.CreatedAt).IsRequired();
        
        builder.Property(c => c.LikeCount).HasDefaultValue(0);
        builder.Property(c => c.ReplyCount).HasDefaultValue(0);

        builder.HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Post)
            .WithMany()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(c => c.ParentComment)
            .WithMany() 
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false); 
    }
}