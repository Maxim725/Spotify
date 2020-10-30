using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Album"/>
	/// </summary>
	public class AlbumAuthor
	{
		public int AuthorId { get; set; }

		public Author Author { get; set; }

		public int AlbumId { get; set; }

		public Album Album { get; set; }
	}
}
