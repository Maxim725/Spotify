using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary> Модель трека </summary>
    public class Track : NamedEntity
    {
        /// <summary> Путь до файла на сервере </summary>
        public string SoundPath { get; set; }

        /// <summary> Продолжительность трека </summary>
        public TimeSpan Duration { get; set; }

        /// <summary> Прослушиваний </summary>
        public uint Auditions { get; set; }

        /// <summary> Дата загрузки трека </summary>
        public DateTime UploadDate { get; set; }

        /// <summary> Альбом, в котором находится трек (может быть null) </summary>
        public Album Album { get; set; }

        /// <summary> Аватарка для трека (может быть null) </summary>
        public Image Image { get; set; }

        /// <summary> Список авторов трека </summary>
        public IEnumerable<Author> Authors { get; set; }

        /// <summary> Список тегов для трека</summary>
        public IEnumerable<TrackTag> Tags { get; set; }

        /// <summary> Жанры, в которых написан трек </summary>
        public IEnumerable<Genre> Genres { get; set; }

    }
}
