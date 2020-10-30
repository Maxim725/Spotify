using Spotify.Domain.Entities.Base;
using Spotify.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Track"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
	/// </summary>
	public class UserLikedTrack
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int TrackId { get; set; }

		public Track Track { get; set; }
	}
}
