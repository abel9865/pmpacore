using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PasswordRecoveryChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAcctRecoveryDetail_AspNetUsers_UserId",
                table: "UserAcctRecoveryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAcctRecoveryDetail",
                table: "UserAcctRecoveryDetail");

            migrationBuilder.RenameTable(
                name: "UserAcctRecoveryDetail",
                newName: "UserAcctRecoveryDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserAcctRecoveryDetail_UserId",
                table: "UserAcctRecoveryDetails",
                newName: "IX_UserAcctRecoveryDetails_UserId");

            migrationBuilder.AddColumn<string>(
                name: "NewPassword",
                table: "UserAcctRecoveryDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAcctRecoveryDetails",
                table: "UserAcctRecoveryDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAcctRecoveryDetails_AspNetUsers_UserId",
                table: "UserAcctRecoveryDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAcctRecoveryDetails_AspNetUsers_UserId",
                table: "UserAcctRecoveryDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAcctRecoveryDetails",
                table: "UserAcctRecoveryDetails");

            migrationBuilder.DropColumn(
                name: "NewPassword",
                table: "UserAcctRecoveryDetails");

            migrationBuilder.RenameTable(
                name: "UserAcctRecoveryDetails",
                newName: "UserAcctRecoveryDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserAcctRecoveryDetails_UserId",
                table: "UserAcctRecoveryDetail",
                newName: "IX_UserAcctRecoveryDetail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAcctRecoveryDetail",
                table: "UserAcctRecoveryDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAcctRecoveryDetail_AspNetUsers_UserId",
                table: "UserAcctRecoveryDetail",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
