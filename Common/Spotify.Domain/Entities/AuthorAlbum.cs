using Spotify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Album"/>
    /// </summary>
    public class AuthorAlbum
    {
        /// <value>
        /// Альбом.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан альбом для связи альбом - автор.")]
        public Album Album { get; set; }

        /// <value>
        /// Автор альбома.
        /// </value>
        [Key, Required(ErrorMessage = "Не указан автор для связи альбом - автор.")]
        public Author Author { get; set; }
    }
}
