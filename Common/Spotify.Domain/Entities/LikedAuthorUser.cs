using Spotify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Identity.User"/>
    /// </summary>
    public class LikedAuthorUser
    {
        /// <value>
        /// Пользователь.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан пользователь для связи пользователь - автор.")]
        public Identity.User User { get; set; }

        /// <value>
        /// Автор.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан автор для связи пользователь - автор.")]
        public Author Author { get; set; }
    }
}
