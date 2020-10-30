using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс трека.
    /// Трек один из основных типов данных для создания подборок.
    /// </summary>
    public class Track : NamedEntity
    {
        /// <value>
        /// Путь до файла.
        /// </value>
        [Required(ErrorMessage = "Путь до музыкального файла не указан.")]
        public string SoundPath { get; set; }

        /// <value>
        /// Продолжительность трека в секундах.
        /// </value>
        [Required(ErrorMessage = "Продолжительность трека не указана.")]
        public uint Duration { get; set; }

        /// <value>
        /// Количество прослушиваний трека.
        /// По умолчанию 0.
        /// </value>
        [Required(ErrorMessage = "Количество прослушиваний трека не указано.")]
        public ulong Plays { get; set; }

        /// <value>
        /// Дата загрузки трека.
        /// </value>
        [Required(ErrorMessage = "Дата загрузки трека не указана.")]
        public DateTime UploadDate { get; set; }

        /// <value>
        /// Альбом, в котором находится трек.
        /// Может быть <c>null</c>.
        /// </value>
        public Album Album { get; set; }

        /// <value>
        /// Аватарка для трека.
        /// Может быть <c>null</c>.
        /// </value>
        public string Image { get; set; }

        /// <value>
        /// Список авторов трека.
        /// </value>
        [Required(ErrorMessage = "Авторы трека не указаны.")]
        public IEnumerable<Author> Authors { get; set; }

        /// <value>
        /// Теги трека.
        /// Может быть пустым.
        /// </value>
        public IEnumerable<TagTrackTag> Tags { get; set; }

        /// <value>
        /// Жанры трека.
        /// </value>
        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<PlaylistTrack> Playlists { get; set; }

    }
}
