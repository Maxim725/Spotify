using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities.Identity
{
	/// <summary>
	/// Пользователь системы.
	/// </summary>
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
}
