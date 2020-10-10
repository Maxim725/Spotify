using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotify.DAL.Migrations
{
    public partial class Attempt666 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedAuthorUsers_AspNetUsers_AuthorId",
                table: "LikedAuthorUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedAuthorUsers_Authors_AuthorId1",
                table: "LikedAuthorUsers");

            migrationBuilder.DropIndex(
                name: "IX_LikedAuthorUsers_AuthorId1",
                table: "LikedAuthorUsers");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "LikedAuthorUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedAuthorUsers_Authors_AuthorId",
                table: "LikedAuthorUsers",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedAuthorUsers_AspNetUsers_UserId",
                table: "LikedAuthorUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedAuthorUsers_Authors_AuthorId",
                table: "LikedAuthorUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedAuthorUsers_AspNetUsers_UserId",
                table: "LikedAuthorUsers");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                table: "LikedAuthorUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LikedAuthorUsers_AuthorId1",
                table: "LikedAuthorUsers",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedAuthorUsers_AspNetUsers_AuthorId",
                table: "LikedAuthorUsers",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedAuthorUsers_Authors_AuthorId1",
                table: "LikedAuthorUsers",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
