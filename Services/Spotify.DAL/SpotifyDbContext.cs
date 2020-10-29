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
        public DbSet<Author> Authors { get; set; } // +

        public DbSet<Album> Albums { get; set; } // +

        public DbSet<Playlist> Playlists { get; set; } // +

        public DbSet<Track> Tracks { get; set; }

        public DbSet<TrackTag> TrackTags { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<TagFamily> TagFamilies { get; set; }

        public DbSet<LikedAuthorUser> LikedAuthorUsers { get; set; }
        
        public DbSet<LikedTrackUser> LikedTrackUsers { get; set; }

        public DbSet<PlaylistUser> PlaylistUsers { get; set; }

        public DbSet<AuthorAlbum> AuthorAlbums { get; set; }

        public DbSet<TagTrackTag> TagTrackTag { get; set; }

        public DbSet<PlaylistTrack> PlaylistTrack { get; set; }

        public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            // Автор <--> Пользователь
            builder.Entity<LikedAuthorUser>()
                .HasKey(t => new { t.UserId, t.AuthorId });
            //.HasNoKey();

            builder.Entity<LikedAuthorUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.LikedAuthors)
                .HasForeignKey(sc => sc.UserId);


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

            builder.Entity<User>()
                .HasMany(u => u.LikedAuthors)
                .WithOne(u => u.User);

            builder.Entity<AuthorAlbum>()
                .HasKey(k => new { k.AlbumId, k.AuthorId });
            builder.Entity<AuthorAlbum>()
                .HasOne(a => a.Album).WithMany(a => a.Authors).HasForeignKey(a => a.AlbumId);
            builder.Entity<AuthorAlbum>()
                .HasOne(a => a.Author).WithMany(a => a.Albums).HasForeignKey(a => a.AuthorId);

            builder.Entity<PlaylistTrack>()
                .HasKey(k => new { k.PlaylistId, k.TrackId });
            builder.Entity<PlaylistTrack>()
                .HasOne(p => p.Playlist).WithMany(t => t.Tracks).HasForeignKey(t => t.TrackId);
            builder.Entity<PlaylistTrack>()
                .HasOne(p => p.Track).WithMany(t => t.Playlists).HasForeignKey(t => t.PlaylistId);

            builder.Entity<TagTrackTag>()
                .HasKey(k => new { k.TrackId, k.TagId });
            builder.Entity<TagTrackTag>()
                .HasOne(t => t.Track).WithMany(t => t.Tags).HasForeignKey(k => k.TagId);
            builder.Entity<TagTrackTag>()
                .HasOne(t => t.Tag).WithMany(t => t.Tracks).HasForeignKey(k => k.TrackId);

            base.OnModelCreating(builder);
        }
    }
}
