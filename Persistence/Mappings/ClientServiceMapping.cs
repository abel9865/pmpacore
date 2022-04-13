using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ClientServiceMapping : IEntityTypeConfiguration<ClientService>
    {
        public void Configure( EntityTypeBuilder<ClientService> entity )
        {
            entity.Property( e => e.ClientServiceId )
                   .HasColumnName( "ClientServiceID" )
                   .ValueGeneratedNever();

            entity.Property( e => e.ClientId ).HasColumnName( "ClientID" );

            entity.Property( e => e.Comment ).HasMaxLength( 500 );

            entity.Property( e => e.CreatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.Pa ).HasColumnName( "PA" );

            entity.Property( e => e.Pm ).HasColumnName( "PM" );

            entity.HasOne( d => d.Client )
                .WithMany( p => p.ClientServices )
                .HasForeignKey( d => d.ClientId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_ClientService_Client" );
        }
    }
}
