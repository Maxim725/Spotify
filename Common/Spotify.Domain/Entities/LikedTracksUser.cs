using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Track"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
    /// </summary>
    public class LikedTracksUser : IdEntity
    {
        /// <value>
        /// Пользователь.
        /// </value>
        public Identity.User User { get; set; }

        /// <value>
        /// Трек.
        /// </value>
        public Track Track { get; set; }
    }
}
