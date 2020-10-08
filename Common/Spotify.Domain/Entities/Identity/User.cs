using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Identity
{
    /// <summary> Пользователь системы </summary>
    public class User : IdentityUser
    {
        /// <summary> Дата создания аккаунта </summary>
        public DateTime CreationDate { get; set; }

        /// <summary> Список плейлистов пользователя </summary>
        public IEnumerable<Playlist> Playlists { get; set; }

        /// <summary> Список понравившихся авторов пользователя </summary>

        public IEnumerable<Author> Authors { get; set; }

        /// <summary> Список понравившихся треков пользователя </summary>
        public IEnumerable<Track> Tracks { get; set; }
    }
}
