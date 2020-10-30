using Spotify.Domain.Entities.Identity;
using Spotify.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;

namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Класс музыкального альбома.
	/// Альбом служит контейнером треков.
	/// Создается пользователем "Система".
	/// </summary>
	public class Album
	{
		public int AlbumId { get; set; }

		public DateTime CreatedOn { get; set; }

		public int CreatedById { get; set; }

		public User CreatedBy { get; set; }

		public DateTime UpdatedOn { get; set; }

		public DateTime PublishedOn { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public List<AlbumAuthor> Authors { get; set; }

		public ulong Plays { get; set; }

		public string Cover { get; set; }

		public List<AlbumTrack> Tracks { get; set; }
	}
}
