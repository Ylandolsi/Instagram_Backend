using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram_Backend.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.ProfilePictureUrl).HasMaxLength(200);
        builder.Property(u => u.CoverPhotoUrl).HasMaxLength(200);
        builder.Property(u => u.Bio).HasMaxLength(500);
    }
    
}