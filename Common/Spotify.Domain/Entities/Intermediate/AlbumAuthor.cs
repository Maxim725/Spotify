namespace Spotify.Domain.Entities.Intermediate
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Entities.Author"/> и <see cref="Entities.Album"/>
    /// </summary>
    public class AlbumAuthor
    {
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
