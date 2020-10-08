using Spotify.Domain.Entities.Base;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary> Плейлист (контейнер песен) </summary>
    public class Playlist : NamedEntity
    {
        /// <summary> Описание плейлиста </summary>
        public string Description { get; set; }

        /// <summary> Дата создания </summary>
        public DateTime CreationDate { get; set; }

        /// <summary> Дата последнего изменения плейлиста </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary> Список песен </summary>
        public IEnumerable<Track> Tracks { get; set; }

        /// <summary> Пользователь, создавший плейлист </summary>
        public User User { get; set; }

        /// <summary> Аватарка плейлиста </summary>
        public Image Image { get; set; }
    }
}
