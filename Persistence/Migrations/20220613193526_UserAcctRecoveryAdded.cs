using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UserAcctRecoveryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Resource_ResourceId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "ResourceId");

            migrationBuilder.CreateTable(
                name: "UserAcctRecoveryDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RecoveryToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestCompleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OldPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAcctRecoveryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAcctRecoveryDetail_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAcctRecoveryDetail_UserId",
                table: "UserAcctRecoveryDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Resources_ResourceId",
                table: "Comments",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "ResourceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Resources_ResourceId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "UserAcctRecoveryDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Resource_ResourceId",
                table: "Comments",
                column: "ResourceId",
                principalTable: "Resource",
                principalColumn: "ResourceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
