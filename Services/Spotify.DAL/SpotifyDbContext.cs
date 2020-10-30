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
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Playlist> Playlists { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TagFamily> TagFamilies { get; set; }


		public DbSet<AlbumAuthor> AlbumAuthor { get; set; }

		public DbSet<AlbumTrack> AlbumTrack { get; set; }

		public DbSet<PlaylistTrack> PlaylistTrack { get; set; }

		public DbSet<UserLikedAlbum> UserLikedAlbum { get; set; }

		public DbSet<UserLikedTrack> UserLikedTrack { get; set; }

		public DbSet<UserLikedAuthor> UserLikedAuthor { get; set; }

		public DbSet<TrackAuthor> TrackAuthor { get; set; }

		public DbSet<TrackGenre> TrackGenre { get; set; }

		public DbSet<TrackTag> TrackTag { get; set; }

		public DbSet<UserSubscription> UserSubscription { get; set; }

		public DbSet<UserPlaylist> UserPlaylist { get; set; }


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserLikedAuthor>()
				.HasKey(t => new { t.UserId, t.AuthorId });

			modelBuilder.Entity<UserLikedAuthor>()
				.HasOne(t => t.User)
				.WithMany(t => t.LikedAuthors)
				.HasForeignKey(t => t.UserId);

			modelBuilder.Entity<UserLikedTrack>()
				.HasKey(t => new { t.UserId, t.TrackId });

			modelBuilder.Entity<UserLikedTrack>()
				.HasOne(t => t.User)
				.WithMany(t => t.LikedTracks)
				.HasForeignKey(t => t.UserId);

			modelBuilder.Entity<UserSubscription>()
				.HasKey(t => new { t.UserId, t.SubscriptionId });

			modelBuilder.Entity<UserSubscription>()
				.HasOne(t => t.User)
				.WithMany(t => t.Subscriptions)
				.HasForeignKey(t => t.UserId);

			modelBuilder.Entity<UserPlaylist>()
				.HasKey(t => new { t.UserId, t.PlaylistId });

			modelBuilder.Entity<UserPlaylist>()
				.HasOne(t => t.User)
				.WithMany(t => t.Playlists)
				.HasForeignKey(t => t.UserId);

			modelBuilder.Entity<PlaylistTrack>()
				.HasKey(t => new { t.PlaylistId, t.TrackId });

			modelBuilder.Entity<PlaylistTrack>()
				.HasOne(t => t.Playlist)
				.WithMany(t => t.Tracks)
				.HasForeignKey(t => t.PlaylistId);

			modelBuilder.Entity<AlbumTrack>()
				.HasKey(t => new { t.AlbumId, t.TrackId });

			modelBuilder.Entity<AlbumTrack>()
				.HasOne(t => t.Album)
				.WithMany(t => t.Tracks)
				.HasForeignKey(t => t.AlbumId);

			modelBuilder.Entity<AlbumAuthor>()
				.HasKey(t => new { t.AlbumId, t.AuthorId });

			modelBuilder.Entity<AlbumAuthor>()
				.HasOne(t => t.Author)
				.WithMany(t => t.Albums)
				.HasForeignKey(t => t.AuthorId);

			modelBuilder.Entity<AlbumAuthor>()
				.HasOne(t => t.Album)
				.WithMany(t => t.Authors)
				.HasForeignKey(t => t.AlbumId);

			modelBuilder.Entity<TrackAuthor>()
				.HasKey(t => new { t.TrackId, t.AuthorId });

			modelBuilder.Entity<TrackAuthor>()
				.HasOne(t => t.Track)
				.WithMany(t => t.Authors)
				.HasForeignKey(t => t.TrackId);

			modelBuilder.Entity<TrackAuthor>()
				.HasOne(t => t.Author)
				.WithMany(t => t.Tracks)
				.HasForeignKey(t => t.AuthorId);

			modelBuilder.Entity<TrackTag>()
				.HasKey(t => new { t.TrackId, t.TagId });

			modelBuilder.Entity<TrackTag>()
				.HasOne(t => t.Track)
				.WithMany(t => t.Tags)
				.HasForeignKey(t => t.TrackId);

			modelBuilder.Entity<TrackGenre>()
				.HasKey(t => new { t.TrackId, t.GenreId });

			modelBuilder.Entity<TrackGenre>()
				.HasOne(t => t.Track)
				.WithMany(t => t.Genres)
				.HasForeignKey(t => t.TrackId);

			modelBuilder.Entity<UserLikedAlbum>()
				.HasKey(t => new { t.UserId, t.AlbumId });

			modelBuilder.Entity<UserLikedAlbum>()
				.HasOne(t => t.User)
				.WithMany(t => t.LikedAlbums)
				.HasForeignKey(t => t.UserId);
		}
	}
}
}
