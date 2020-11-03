using Spotify.Domain.Entities.Identity;
using Spotify.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс плейлиста.
    /// Служит контейнером треков.
    /// </summary>
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
}
