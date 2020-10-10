using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс музыкального альбома.
    /// Альбом служит контейнером треков.
    /// Создается пользователем "Система".
    /// </summary>
    public class Album : NamedEntity
    {
        /// <value>
        /// Описание альбомв.
        /// </value>
        public string Description { get; set; }

        /// <value>
        /// Дата создания.
        /// </value>
        [Required(ErrorMessage = "Дата создания плейлиста не указана.")]
        public DateTime CreationDate { get; set; }

        /// <value>
        /// Дата последнего изменения альбомв.
        /// </value>
        [Required(ErrorMessage = "Дата обновления плейлиста не указана.")]
        public DateTime UpdateDate { get; set; }

        /// <value>
        /// Список песен.
        /// </value>
        public IEnumerable<Track> Tracks { get; set; }

        /// <value>
        /// Количесво прослушиваний треков данного автора.
        /// Прослушивания обновляются один раз в рассчетный период, к примеру, раз в сутки.
        /// По умолчанию 0.
        /// </value>
        [Required(ErrorMessage = "Количество прослушиваний плейлиста не указано.")]
        public ulong Plays { get; set; }

        /// <value>
        /// Продолжительность альбома в секундах.
        /// По умолчанию 0.
        /// </value>
        [Required(ErrorMessage = "Продолжительность альбома не указана.")]
        public uint Duration { get; set; }

        /// <value>
        /// Дата публикации.
        /// Часто является примерной датой.
        /// Например, январь 2020.
        /// Может быть <c>null</c>.
        /// </value>
        public DateTime PublicationDate { get; set; }

        /// <value>
        /// Авторы альбома.
        /// </value>
        [Required(ErrorMessage = "Авторы альбома не указаны.")]
        public IEnumerable<AuthorAlbum> Authors { get; set; }

        /// <value>
        /// Обложка альбома.
        /// </value>
        [Required(ErrorMessage = "Обложка альбома не указана.")]
        public string Cover { get; set; }
    }
}
