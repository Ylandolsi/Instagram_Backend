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

            // when a new entity is added to UserFollower
            // the UserFollow will be added to the FollowingRelationships collection of Follower User
            builder.HasOne( uf => uf.Follower)
                .WithMany( u => u.FollowingRelationships )
                .HasForeignKey( uf => uf.FollowerId )
                .OnDelete(DeleteBehavior.NoAction);
                
            builder.HasOne( uf => uf.Following)
                .WithMany( u => u.FollowerRelationships )
                .HasForeignKey( uf => uf.FollowingId )
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}