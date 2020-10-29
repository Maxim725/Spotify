using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotify.DAL.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Playlists_PlaylistId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackTags_Tracks_TrackId",
                table: "TrackTags");

            migrationBuilder.DropIndex(
                name: "IX_TrackTags_TrackId",
                table: "TrackTags");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "TrackTags");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Tracks");

            migrationBuilder.CreateTable(
                name: "PlaylistTrack",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false),
                    PlaylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTrack", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Tracks_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Playlists_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagTrackTag",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTrackTag", x => new { x.TrackId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagTrackTag_Tracks_TagId",
                        column: x => x.TagId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTrackTag_TrackTags_TrackId",
                        column: x => x.TrackId,
                        principalTable: "TrackTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTrack_TrackId",
                table: "PlaylistTrack",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTrackTag_TagId",
                table: "TagTrackTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistTrack");

            migrationBuilder.DropTable(
                name: "TagTrackTag");

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "TrackTags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackTags_TrackId",
                table: "TrackTags",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Tracks",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Playlists_PlaylistId",
                table: "Tracks",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackTags_Tracks_TrackId",
                table: "TrackTags",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
