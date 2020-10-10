using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Album"/>
    /// </summary>
    public class AuthorAlbum : IdEntity
    {
        /// <value>
        /// Альбом.
        /// </value>
        public Album Album { get; set; }

        /// <value>
        /// Автор альбома.
        /// </value>
        public Author Author { get; set; }
    }
}
