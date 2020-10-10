using Spotify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Track"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
    /// </summary>
    public class LikedTracksUser
    {
        /// <value>
        /// Пользователь.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан пользователь для связи пользователь - трек.")]
        public Identity.User User { get; set; }

        /// <value>
        /// Трек.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан трек для связи пользователь - трек.")]
        public Track Track { get; set; }
    }
}
