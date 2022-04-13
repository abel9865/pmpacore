using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UserRoleMapping:IEntityTypeConfiguration<UserRole>
    {
        public void Configure( EntityTypeBuilder<UserRole> entity )
        {

            entity.ToTable( "UserRole" );
            //entity.ToTable( "CustomAPIModel" );
            entity.Property( e => e.UserRoleId )
                      .HasColumnName( "UserRoleID" )
                      .ValueGeneratedNever();

            entity.Property( e => e.Comments ).HasMaxLength( 1000 );

            entity.Property( e => e.CreatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.RoleId ).HasColumnName( "RoleID" );

            entity.Property( e => e.UserId ).HasColumnName( "UserID" );

            entity.HasOne( d => d.Role )
                .WithMany( p => p.UserRoles )
                .HasForeignKey( d => d.RoleId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserRole_Role" );

            entity.HasOne( d => d.User )
             .WithMany( p => p.UserRoles )
             .HasForeignKey( d => d.UserId )
             .OnDelete( DeleteBehavior.ClientSetNull )
             .HasConstraintName( "FK_UserRole_User" );
        }
    }
}
