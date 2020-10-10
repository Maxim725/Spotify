using Spotify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Playlist"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
    /// </summary>
    public class PlaylistUser
    {
        public int UserId { get; set; }
        public int PlaylistId { get; set; }

        /// <value>
        /// Пользователь.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан пользователь для связи пользователь - плэйлист.")]
        public Identity.User User { get; set; }

        /// <value>
        /// Плейлист.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан плэйлист для связи пользователь - плэйлист.")]
        public Playlist Playlist { get; set; }
    }
}
