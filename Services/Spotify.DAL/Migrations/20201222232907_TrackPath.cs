using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotify.DAL.Migrations
{
    public partial class TrackPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Tracks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Tracks");
        }
    }
}
