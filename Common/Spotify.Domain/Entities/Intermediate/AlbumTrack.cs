using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities.Intermediate
{
	public class AlbumTrack
	{
		public int AlbumId { get; set; }

		public Album Album { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}
}
