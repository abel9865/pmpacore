using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PMPAUserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> entity )
        {

  entity.ToTable( "PMPAUser" );
  entity.HasKey( e=>e.UserId);

            entity.Property( e => e.UserId )
                   .HasColumnName( "UserID" )
                   .ValueGeneratedNever();

            entity.Property( e => e.Address1 ).HasMaxLength( 200 );

            entity.Property( e => e.Address2 ).HasMaxLength( 200 );

            entity.Property( e => e.B1recordId )
                .HasColumnName( "B1RecordID" )
                .HasMaxLength( 20 );

            entity.Property( e => e.B1syncFailureReason )
                .HasColumnName( "B1SyncFailureReason" )
                .HasMaxLength( 500 );

            entity.Property( e => e.City ).HasMaxLength( 50 );

            entity.Property( e => e.ClientId ).HasColumnName( "ClientID" );

            entity.Property( e => e.CompanyCode ).HasMaxLength( 50 );

            entity.Property( e => e.CompanyName ).HasMaxLength( 100 );

            entity.Property( e => e.Country ).HasMaxLength( 50 );

            entity.Property( e => e.CreateDateTime ).HasColumnType( "datetime" );

           // entity.Property( e => e.Email ).HasMaxLength( 50 );

            entity.Property( e => e.Fax ).HasMaxLength( 20 );

            entity.Property( e => e.FirstName ).HasMaxLength( 50 );

            entity.Property( e => e.LastName ).HasMaxLength( 50 );

            entity.Property( e => e.LastUpdateDateTime ).HasColumnType( "datetime" );

            entity.Property( e => e.Password )
                .HasMaxLength( 250 )
                .IsUnicode( false );

            entity.Property( e => e.Phone ).HasMaxLength( 20 );

            entity.Property( e => e.ProfilePath ).HasMaxLength( 50 );

            entity.Property( e => e.QryGroup1 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup10 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup11 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup12 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup13 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup14 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup15 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup16 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup17 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup18 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup19 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup2 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup20 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup21 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup22 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup23 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup24 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup25 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup26 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup27 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup28 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup29 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup3 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup30 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup31 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup32 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup33 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup34 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup35 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup36 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup37 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup38 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup39 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup4 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup40 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup41 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup42 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup43 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup44 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup45 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup46 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup47 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup48 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup49 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup5 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup50 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup51 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup52 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup53 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup54 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup55 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup56 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup57 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup58 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup59 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup6 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup60 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup61 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup62 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup63 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup64 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup7 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup8 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "('N')" );

            entity.Property( e => e.QryGroup9 )
                .HasMaxLength( 1 )
                .IsUnicode( false )
                .IsFixedLength()
                .HasDefaultValueSql( "(N'N')" );

            entity.Property( e => e.State ).HasMaxLength( 50 );

            entity.Property( e => e.Zip ).HasMaxLength( 20 );

            entity.HasOne( d => d.LastUpdatedByNavigation )
                .WithMany( p => p.InverseLastUpdatedByNavigation )
                .HasForeignKey( d => d.LastUpdatedBy )
                .HasConstraintName( "FK_User_User_LastUpdateByUserId" );

            entity.HasOne( d => d.Client )
               .WithMany( p => p.Users )
               .HasForeignKey( d => d.ClientId )
               .OnDelete( DeleteBehavior.ClientSetNull )
               .HasConstraintName( "FK_PMPAUser_Client" );
        }
    }
}
