using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities.Identity
{
    /// <summary>
    /// Пользователь системы.
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Дата создания аккаунта.
        /// </summary>
        [Required(ErrorMessage = "Дата создания пользователя не указана.")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Список плейлистов пользователя.
        /// </summary>
        public IEnumerable<PlaylistUser> Playlists { get; set; }

        /// <summary>
        /// Список понравившихся авторов пользователя.
        /// </summary>
        public IEnumerable<LikedAuthorUser> LikedAuthors { get; set; }
        //public IEnumerable<Author> LikedAuthors { get; set; }

        /// <summary>
        /// Список понравившихся треков пользователя.
        /// </summary>
        public IEnumerable<LikedTrackUser> LikedTracks { get; set; }

        /// <value>
        /// Аватар пользователя.
        /// </value>
        [Required(ErrorMessage = "Аватар пользователя не указан.")]
        public string Avatar { get; set; }
    }
}
