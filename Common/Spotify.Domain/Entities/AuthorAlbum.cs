using Spotify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Spotify.Domain.Entities.Author"/> и <see cref="Spotify.Domain.Entities.Album"/>
    /// </summary>
    public class AuthorAlbum
    {
        public int AlbumId { get; set; }
        public int AuthorId { get; set; }
            
        /// <value>
        /// Альбом.
        /// </value>
        //[Key, Required(ErrorMessage = "Не указан альбом для связи альбом - автор.")]
        //[ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }

        /// <value>
        /// Автор альбома.
        /// </value>
        //[Key, Required(ErrorMessage = "Не указан автор для связи альбом - автор.")]
        //[ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }
    }
}
