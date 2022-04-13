using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure( EntityTypeBuilder<Client> entity )
        {


            entity.Property( e => e.ClientId )
                  .HasColumnName( "ClientID" )
                  .ValueGeneratedNever();

            entity.Property( e => e.ClientCode )
                .IsRequired()
                .HasMaxLength( 10 );

            entity.Property( e => e.ClientName )
                .IsRequired()
                .HasMaxLength( 100 );

            entity.Property( e => e.Comments ).HasMaxLength( 1000 );


            //entity.ToTable( "PMPA_Client" );

            //entity.HasIndex( e => e.ClientId )
            //      .HasDatabaseName( "ClientID" );

            //entity.Property( e => e.ClientId )
            //       .HasColumnName( "ClientID" )
            //       .ValueGeneratedNever();

            //entity.Property( e => e.ClientCode )
            //    .IsRequired()
            //    .HasMaxLength( 10 );

            //entity.Property( e => e.ClientName )
            //    .IsRequired()
            //    .HasMaxLength( 100 );

            //entity.Property( e => e.Comments ).HasMaxLength( 1000 );






            //entity.Property( e => e.Id ).HasColumnName( "AoID" );

            //entity.Property( e => e.Key ).HasColumnName( "AoKey" );

            //entity.Property( e => e.Value ).HasColumnName( "AoValue" );

            //entity.Property( e => e.Description ).HasColumnName( "AoDescription" );

            //entity.Property( e => e.Status ).HasColumnName( "AoStatus" );

            //entity.Property( e => e.Group ).HasColumnName( "AoGroup" );
        }
    }
}
