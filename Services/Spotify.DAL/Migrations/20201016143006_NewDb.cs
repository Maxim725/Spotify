using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spotify.DAL.Migrations
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAlbums_Playlists_AlbumId",
                table: "AuthorAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Playlists_AlbumId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Playlists");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Plays = table.Column<decimal>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    Cover = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Tracks",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAlbums_Albums_AlbumId",
                table: "AuthorAlbums",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Playlists_PlaylistId",
                table: "Tracks",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorAlbums_Albums_AlbumId",
                table: "AuthorAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Playlists_PlaylistId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_PlaylistId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Tracks");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Playlists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorAlbums_Playlists_AlbumId",
                table: "AuthorAlbums",
                column: "AlbumId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Playlists_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
