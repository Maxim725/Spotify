using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotify.DAL.Migrations
{
    public partial class AddTableTagFamily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackTags_TrackTags_TrackTagId",
                table: "TrackTags");

            migrationBuilder.DropIndex(
                name: "IX_TrackTags_TrackTagId",
                table: "TrackTags");

            migrationBuilder.DropColumn(
                name: "TrackTagId",
                table: "TrackTags");

            migrationBuilder.CreateTable(
                name: "TagFamilies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TrackTagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagFamilies", x => x.id);
                    table.ForeignKey(
                        name: "FK_TagFamilies_TrackTags_TrackTagId",
                        column: x => x.TrackTagId,
                        principalTable: "TrackTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagFamilies_TrackTagId",
                table: "TagFamilies",
                column: "TrackTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagFamilies");

            migrationBuilder.AddColumn<int>(
                name: "TrackTagId",
                table: "TrackTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackTags_TrackTagId",
                table: "TrackTags",
                column: "TrackTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackTags_TrackTags_TrackTagId",
                table: "TrackTags",
                column: "TrackTagId",
                principalTable: "TrackTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
