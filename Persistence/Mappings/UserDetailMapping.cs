using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UserDetailMapping : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure( EntityTypeBuilder<UserDetail> entity )
        {
  entity.ToTable( "UserDetail" );
  entity.HasKey( e=>e.UserDetailId);

            entity.Property( e => e.UserDetailId )
                  .HasColumnName( "Id" )
                  .ValueGeneratedNever();

            entity.Property( e => e.Initiateddatetime ).HasColumnType( "datetime" );

            entity.Property( e => e.Newpwd )
                .HasMaxLength( 250 )
                .IsUnicode( false );

            entity.Property( e => e.Oldpwd )
                .HasMaxLength( 250 )
                .IsUnicode( false );

            entity.Property( e => e.Setdatetime ).HasColumnType( "datetime" );

            entity.Property( e => e.UniqueId )
                .HasMaxLength( 250 )
                .IsUnicode( false );

            entity.Property( e => e.UserId ).HasColumnName( "UserID" );

            entity.HasOne( d => d.User )
                .WithMany( p => p.UserDetails )
                .HasForeignKey( d => d.UserId )
                .OnDelete( DeleteBehavior.ClientSetNull )
                .HasConstraintName( "FK_UserDetail_User" );


            //entity.HasOne( d => d.User )
            // .WithMany( p => p.VgoUserDetails )
            // .HasForeignKey( d => d.UserId )
            // .HasConstraintName( "FK_VGO_USR3_UserId_WS_OUSR_ID" );
        }
    }
}
