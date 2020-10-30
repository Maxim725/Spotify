using Spotify.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс автора музыки.
    /// </summary>
    public class Author
	{
		public int AuthorId { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime UpdatedOn { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public ulong Plays { get; set; }

		public string Avatar { get; set; }

		public List<AlbumAuthor> Albums { get; }

		public List<TrackAuthor> Tracks { get; }
	}
}
