using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UserProjectMapping : IEntityTypeConfiguration<UserProject>
    {
        public void Configure( EntityTypeBuilder<UserProject> entity )
        {
  entity.ToTable( "UserProject" );
  entity.HasKey( e=>e.UserProjectId);

            entity.Property( e => e.UserProjectId )
                  .HasColumnName( "UserProjectID" )
                  .ValueGeneratedNever();

            entity.Property( e => e.Comment ).HasMaxLength( 1000 );

            entity.Property( e => e.CreatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.ProjectId ).HasColumnName( "ProjectID" );

            entity.Property( e => e.UserId ).HasColumnName( "UserID" );

            entity.Property( e => e.UserProjectId ).HasColumnName( "UserProjectID" );

            entity.HasOne( d => d.Project )
                .WithMany()
                .HasForeignKey( d => d.ProjectId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserProject_ClientProject" );

            entity.HasOne( d => d.User )
                .WithMany( p => p.UserProjects )
                .HasForeignKey( d => d.UserId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserProject_User" );
        }
    }
}
