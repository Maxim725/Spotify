using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities
{
	public class UserLikedAlbum
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }
	}
}
