using Instagram_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram_Backend.Database.Configurations
{
    public class UserFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(uf => new { uf.FollowerId, uf.FollowingId });

            builder.HasOne( uf => uf.Follower)
                .WithMany( u => u.Following )
                .HasForeignKey( uf => uf.FollowerId )
                .OnDelete(DeleteBehavior.NoAction);
                
            builder.HasOne( uf => uf.Following)
                .WithMany( u => u.Followers )
                .HasForeignKey( uf => uf.FollowingId )
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}