using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
    /// </summary>
    public class LikedAuthorUser : IdEntity
    {
        /// <value>
        /// Пользователь.
        /// </value>
        public Identity.User User { get; set; }

        /// <value>
        /// Автор.
        /// </value>
        public Author Author { get; set; }
    }
}
