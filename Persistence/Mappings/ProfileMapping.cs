using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure( EntityTypeBuilder<Profile> entity )
        {
            entity.Property( e => e.ProfileId ).HasColumnName( "ProfileID" );

            entity.Property( e => e.ConnectionId ).HasColumnName( "ConnectionID" );

            entity.Property( e => e.CreatedByDate ).HasColumnType( "datetime" );

            entity.Property( e => e.LastUpdatedDate ).HasColumnType( "datetime" );

            entity.Property( e => e.ProfileName ).HasMaxLength( 50 );

            entity.Property( e => e.Remark ).HasMaxLength( 500 );

            entity.Property( e => e.SourceTableName ).HasMaxLength( 250 );
        }
    }
}
