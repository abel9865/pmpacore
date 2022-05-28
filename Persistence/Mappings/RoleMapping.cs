using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure( EntityTypeBuilder<Role> entity )
        {

            entity.ToTable( "Role" );
entity.HasKey( e=>e.RoleId);
            entity.Property( e => e.RoleId )
                    .HasColumnName( "RoleID" )
                    .ValueGeneratedNever();

            entity.Property( e => e.CreatedDate ).HasColumnType( "datetime" );

          

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.ProjectId ).HasColumnName( "ProjectID" );

            entity.Property( e => e.RoleName )
                .IsRequired()
                .HasMaxLength( 50 );

            entity.HasOne( d => d.Project )
                .WithMany( p => p.Role )
                .HasForeignKey( d => d.ProjectId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_Role_ClientProject" );


            //      entity.HasMany(x=>x.UserRoles)
            // .WithOne()
            // .HasForeignKey(e=>e.RoleId);
        }
    }
}
