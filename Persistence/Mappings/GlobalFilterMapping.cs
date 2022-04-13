using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class GlobalFilterMapping : IEntityTypeConfiguration<GlobalFilter>
    {
        public void Configure( EntityTypeBuilder<GlobalFilter> entity )
        {
            entity.Property( e => e.GlobalFilterId )
                    .HasColumnName( "GlobalFilterID" )
                    .ValueGeneratedNever();

            entity.Property( e => e.ConnectionId ).HasColumnName( "ConnectionID" );

            entity.Property( e => e.CreatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.GlobalFilterName )
                .IsRequired()
                .HasMaxLength( 250 );

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.Remark ).HasMaxLength( 500 );

            entity.Property( e => e.SourceTableName ).HasMaxLength( 250 );
        }
    }
}
