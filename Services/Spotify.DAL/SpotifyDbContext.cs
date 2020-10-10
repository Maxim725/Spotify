using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.DAL
{
    public class SpotifyDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Author> Authros { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<TrackTag> TrackTags { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<TagFamily> TagFamilies { get; set; }

        public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Автор <--> Альбом
            builder.Entity<AuthorAlbum>()
                .HasKey(t => new { t.AuthorId, t.AlbumId });

            builder.Entity<AuthorAlbum>()
                .HasOne(sc => sc.Author)
                .WithMany(s => s.Albums)
                .HasForeignKey(sc => sc.AuthorId);

            builder.Entity<AuthorAlbum>()
                .HasOne(sc => sc.Album)
                .WithMany(s => s.Authors)
                .HasForeignKey(sc => sc.AlbumId);


            // Автор <--> Пользователь
            builder.Entity<LikedAuthorUser>()
                .HasKey(t => new { t.UserId, t.AuthorId });

            builder.Entity<LikedAuthorUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.LikedAuthors)
                .HasForeignKey(sc => sc.UserId)
                .HasForeignKey(sc => sc.AuthorId);


            // Трек <--> Пользователь
            builder.Entity<LikedTrackUser>()
                .HasKey(t => new { t.UserId, t.TrackId });

            builder.Entity<LikedTrackUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.LikedTracks)
                .HasForeignKey(sc => sc.UserId);


            // Плэйлист <--> Пользователь
            builder.Entity<PlaylistUser>()
                .HasKey(t => new { t.UserId, t.PlaylistId });

            builder.Entity<PlaylistUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.Playlists)
                .HasForeignKey(sc => sc.UserId);
        }
    }
}
