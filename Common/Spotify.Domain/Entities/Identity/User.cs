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
    public class User : IdentityUser
    {
        /// <summary>
        /// Дата создания аккаунта.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Список плейлистов пользователя.
        /// </summary>
        public IEnumerable<Playlist> Playlists { get; set; }

        /// <summary>
        /// Список понравившихся авторов пользователя.
        /// </summary>
        public IEnumerable<Author> LikedAuthors { get; set; }

        /// <summary>
        /// Список понравившихся треков пользователя.
        /// </summary>
        public IEnumerable<Track> LikedTracks { get; set; }

        /// <value>
        /// Аватар пользователя.
        /// </value>
        public string Avatar { get; set; }
    }
}
