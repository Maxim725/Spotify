using Spotify.Domain.Entities.Base;
using Spotify.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Playlist"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
	/// </summary>
	public class UserPlaylist
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int PlaylistId { get; set; }

		public Playlist Playlist { get; set; }
	}
}
