using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Playlist"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
    /// </summary>
    public class PlaylistUser : IdEntity
    {
        /// <value>
        /// Пользователь.
        /// </value>
        public Identity.User User { get; set; }

        /// <value>
        /// Плейлист.
        /// </value>
        public Playlist Playlist { get; set; }
    }
}
