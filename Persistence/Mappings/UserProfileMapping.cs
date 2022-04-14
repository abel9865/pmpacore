using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UserProfileMapping : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure( EntityTypeBuilder<UserProfile> entity )
        {
  entity.ToTable( "UserProfile" );
entity.HasKey( e=>e.UserProfileId);
            entity.Property( e => e.UserProfileId )
                    .HasColumnName( "UserProfileID" )
                    .ValueGeneratedNever();

            entity.Property( e => e.ProfileFieldName )
                .IsRequired()
                .HasMaxLength( 500 );

            entity.Property( e => e.ProfileFieldValue )
                .IsRequired()
                .HasMaxLength( 500 );

            entity.Property( e => e.ProfileId ).HasColumnName( "ProfileID" );

            entity.Property( e => e.UserId ).HasColumnName( "UserID" );

            entity.HasOne( d => d.Profile )
                .WithMany( p => p.UserProfiles )
                .HasForeignKey( d => d.ProfileId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserProfile_Profile" );

            entity.HasOne( d => d.User )
                .WithMany( p => p.UserProfiles )
                .HasForeignKey( d => d.UserId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserProfile_User" );
        }
    }
}
