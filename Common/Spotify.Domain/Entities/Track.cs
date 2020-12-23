using Spotify.Domain.Entities.Identity;
using Spotify.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;

namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Класс трека.
	/// Трек один из основных типов данных для создания подборок.
	/// </summary>
	public class Track
	{
		public int TrackId { get; set; }

		public DateTime CreatedOn { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public String Title { get; set; }

		public IEnumerable<TrackAuthor> Authors { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }

		public uint Duration { get; set; }

		public ulong Plays { get; set; }

		public IEnumerable<TrackGenre> Genres { get; set; }

		public IEnumerable<TrackTag> Tags { get; set; }

		public string Path { get; set; }
	}
}
