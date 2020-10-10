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

        public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Автор <--> Альбом
            //builder.Entity<AuthorAlbum>()
            //    .HasKey(t => new { t.AuthorId, t.AlbumId });

            //builder.Entity<AuthorAlbum>()
            //    .HasOne(sc => sc.Author)
            //    .WithMany(s => s.Albums)
            //    .HasForeignKey(sc => sc.AuthorId);

            //builder.Entity<AuthorAlbum>()
            //    .HasOne(sc => sc.Album)
            //    .WithMany(s => s.Authors)
            //    .HasForeignKey(sc => sc.AlbumId);


            // Автор <--> Пользователь
            builder.Entity<LikedAuthorUser>()
                .HasKey(t => new { t.UserId, t.AuthorId });
            //.HasNoKey();

            builder.Entity<LikedAuthorUser>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.LikedAuthors)
                .HasForeignKey(sc => sc.UserId);
            //.HasForeignKey(sc => sc.AuthorId);
            //builder.Entity<LikedAuthorUser>()
            //    .HasOne(sc => sc.Author)
            //    .WithMany(sc => sc.)
            //    .HasForeignKey();


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
            //.HasNoKey();
            builder.Entity<AuthorAlbum>()
                .HasOne(a => a.Album).WithMany(a => a.Authors).HasForeignKey(a => a.AlbumId);
            builder.Entity<AuthorAlbum>()
                .HasOne(a => a.Author).WithMany(a => a.Albums).HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
