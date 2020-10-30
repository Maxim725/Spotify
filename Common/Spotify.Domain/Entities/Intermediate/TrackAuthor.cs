using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities.Intermediate
{
	public class TrackAuthor
	{
		public int AuthorId { get; set; }

		public Author Author { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}
}
