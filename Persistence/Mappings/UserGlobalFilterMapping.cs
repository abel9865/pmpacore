using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UserGlobalFilterMapping : IEntityTypeConfiguration<UserGlobalFilter>
    {
        public void Configure( EntityTypeBuilder<UserGlobalFilter> entity )
        {
            entity.Property( e => e.UserGlobalFilterId )
                    .HasColumnName( "UserGlobalFilterID" )
                    .ValueGeneratedNever();

            entity.Property( e => e.GlobalFilterFieldName )
                .IsRequired()
                .HasMaxLength( 250 );

            entity.Property( e => e.GlobalFilterFieldValue )
                .IsRequired()
                .HasMaxLength( 250 );

            entity.Property( e => e.GlobalFilterId ).HasColumnName( "GlobalFilterID" );

            entity.Property( e => e.UserId ).HasColumnName( "UserID" );

            entity.HasOne( d => d.GlobalFilter )
                .WithMany( p => p.UserGlobalFilter )
                .HasForeignKey( d => d.GlobalFilterId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserGlobalFilter_GlobalFilter" );

            entity.HasOne( d => d.User )
                .WithMany( p => p.UserGlobalFilter )
                .HasForeignKey( d => d.UserId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserGlobalFilter_User" );
        }
    }
}
