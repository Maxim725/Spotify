namespace Spotify.Domain.Entities
{
	/// <summary>
	/// Класс жанра музыки.
	/// </summary>
	public class Genre
	{
		public int GenreId { get; set; }

		public string Description { get; set; }

		public ulong Plays { get; set; }
	}
}