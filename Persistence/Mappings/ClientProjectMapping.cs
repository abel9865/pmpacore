using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ClientProjectMapping : IEntityTypeConfiguration<ClientProject>
    {
        public void Configure( EntityTypeBuilder<ClientProject> entity )
        {
  entity.ToTable( "ClientProject" );

            entity.HasKey( e => e.ProjectId );

            entity.Property( e => e.ProjectId )
                .HasColumnName( "ProjectID" )
                .ValueGeneratedNever();

            entity.Property( e => e.ClientId ).HasColumnName( "ClientID" );

            entity.Property( e => e.CreatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.ProjectTitle )
                .IsRequired()
                .HasMaxLength( 200 );

                entity.Property( e => e.ProjectDescription )
                .IsRequired()
                .HasMaxLength( 2000 );

            entity.HasOne( d => d.Client )
                .WithMany( p => p.ClientProjects )
                .HasForeignKey( d => d.ClientId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_ClientProject_Client" );
        }
    }
}
