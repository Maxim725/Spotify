using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotify.DAL.Migrations
{
    public partial class ModelUpdate_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authros_AspNetUsers_UserId",
                table: "Authros");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_AspNetUsers_UserId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_UserId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Authros_UserId",
                table: "Authros");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Authros");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Playlists",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AspNetRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "LikedAuthorUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    AuthorId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedAuthorUser", x => new { x.UserId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_LikedAuthorUser_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedAuthorUser_Authros_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "Authros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedTrackUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedTrackUser", x => new { x.UserId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_LikedTrackUser_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedTrackUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistUser", x => new { x.UserId, x.PlaylistId });
                    table.ForeignKey(
                        name: "FK_PlaylistUser_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedAuthorUser_AuthorId",
                table: "LikedAuthorUser",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedAuthorUser_AuthorId1",
                table: "LikedAuthorUser",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_LikedTrackUser_TrackId",
                table: "LikedTrackUser",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistUser_PlaylistId",
                table: "PlaylistUser",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedAuthorUser");

            migrationBuilder.DropTable(
                name: "LikedTrackUser");

            migrationBuilder.DropTable(
                name: "PlaylistUser");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tracks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "Playlists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Authros",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_UserId",
                table: "Tracks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authros_UserId",
                table: "Authros",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authros_AspNetUsers_UserId",
                table: "Authros",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_AspNetUsers_UserId",
                table: "Tracks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
