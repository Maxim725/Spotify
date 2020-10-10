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
        [DataType(DataType.Url)]
        [Required(ErrorMessage = "Путь до музыкального файла не указан.")]
        public string SoundPath { get; set; }

        /// <value>
        /// Продолжительность трека в секундах.
        /// </value>
        [DataType(DataType.Url)]
        [Required(ErrorMessage = "Продолжительность трека не указана.")]
        public uint Duration { get; set; }

        /// <value>
        /// Количество прослушиваний трека.
        /// По умолчанию 0.
        /// </value>
        [Required(ErrorMessage = "Количество прослушиываний трека не указано.")]
        public uint Plays { get; set; }

        /// <value>
        /// Дата загрузки трека.
        /// </value>
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Количество прослушиываний трека не указано.")]
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
        public IEnumerable<TrackTag> Tags { get; set; }

        /// <value>
        /// Жанры трека.
        /// </value>
        public IEnumerable<Genre> Genres { get; set; }

    }
}
