using Spotify.Domain.Entities.Base;
using Spotify.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
	/// </summary>
	public class UserLikedAuthor
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int AuthorId { get; set; }

		public Author Author { get; set; }
	}
}
