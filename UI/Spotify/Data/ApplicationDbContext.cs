using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Data
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

	public class User : IdentityUser<int>
	{
		public int UserId { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }

		public String Avatar { get; set; }

		public List<UserLikedAuthor> LikedAuthors { get; set; }

		public List<UserLikedTrack> LikedTracks { get; set; }

		public List<UserSubscription> Subscriptions { get; set; }

		public List<UserLikedAlbum> LikedAlbums { get; set; }

		public List<UserPlaylist> Playlists { get; set; }
	}

	public class UserLikedAuthor
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int AuthorId { get; set; }

		public Author Author { get; set; }
	}

	public class UserLikedTrack
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}

	public class UserSubscription
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int SubscriptionId { get; set; }

		public User Subscription { get; set; }
	}

	public class UserPlaylist
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int PlaylistId { get; set; }

		public Playlist Playlist { get; set; }
	}

	public class UserLikedAlbum
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }
	}

	public class Playlist
	{
		public int PlaylistId { get; set; }

		public DateTime CreatedOn { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public DateTime UpdatedOn { get; set; }

		public DateTime PublishedOn { get; set; }

		public String Title { get; set; }

		public String Description { get; set; }

		public ulong Plays { get; set; }

		public List<PlaylistTrack> Tracks { get; set; }
	}

	public class PlaylistTrack
	{
		public int PlaylistId { get; set; }

		public Playlist Playlist { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}

	public class Album
	{
		public int AlbumId { get; set; }

		public DateTime CreatedOn { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public DateTime UpdatedOn { get; set; }

		public DateTime PublishedOn { get; set; }

		public String Title { get; set; }

		public String Description { get; set; }

		public List<AlbumAuthor> Authors { get; set; }

		public ulong Plays { get; set; }

		public string Cover { get; set; }

		public List<AlbumTrack> Tracks { get; set; }
	}

	public class AlbumTrack
	{
		public int AlbumId { get; set; }

		public Album Album { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}

	public class Author
	{
		public int AuthorId { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }

		public String Name { get; set; }

		public String Description { get; set; }

		public ulong Plays { get; set; }

		public string Avatar { get; set; }

		public List<AlbumAuthor> Albums { get; }

		public List<TrackAuthor> Tracks { get; }
	}

	public class AlbumAuthor
	{
		public int AuthorId { get; set; }

		public Author Author { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }
	}

	public class TrackAuthor
	{
		public int AuthorId { get; set; }

		public Author Author { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}

	public class Track
	{
		public int TrackId { get; set; }

		public DateTime CreatedOn { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public String Title { get; set; }

		public List<TrackAuthor> Authors { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }

		public uint Duration { get; set; }

		public ulong Plays { get; set; }

		public List<TrackGenre> Genres { get; set; }

		public List<TrackTag> Tags { get; set; }
	}

	public class TrackTag
	{
		public int TrackId { get; set; }

		public Track Track { get; set; }

		public int TagId { get; set; }

		public Tag Tag { get; set; }
	}

	public class TrackGenre
	{
		public int TrackId { get; set; }

		public Track Track { get; set; }

		public int GenreId { get; set; }

		public Genre Genre { get; set; }
	}

	public class Genre
	{
		public int GenreId { get; set; }

		public String Description { get; set; }

		public ulong Plays { get; set; }
	}

	public class Tag
	{
		public int TagId { get; set; }

		public String Name { get; set; }

		public int FamilyId { get; set; }

		public TagFamily Family { get; set; }
	}

	public class TagFamily
	{
		public int TagFamilyId { get; set; }

		public String Name { get; set; }

		public List<Tag> Tags { get; }
	}
}
