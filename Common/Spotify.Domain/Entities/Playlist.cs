using Spotify.Domain.Entities.Base;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс плейлиста.
    /// Служит контейнером треков.
    /// </summary>
    public class Playlist : NamedEntity
    {
        /// <value>
        /// Описание плейлиста.
        /// </value>
        public string Description { get; set; }

        /// <value>
        /// Дата создания.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <value>
        /// Дата последнего изменения плейлиста.
        /// </value>
        public DateTime UpdateDate { get; set; }

        /// <value>
        /// Список песен.
        /// </value>
        public IEnumerable<Track> Tracks { get; set; }

        /// <value>
        /// Создатель плейлиста.
        /// </value>
        public User CreatedBy { get; set; }

        /// <value>
        /// Количесво прослушиваний треков данного автора.
        /// Прослушивания обновляются один раз в рассчетный период, к примеру, раз в сутки.
        /// По умолчанию 0.
        /// </value>
        public ulong Plays { get; set; }

        /// <value>
        /// Продолжительность плейлиста в секундах.
        /// По умолчанию 0.
        /// </value>
        public uint Duration { get; set; }
    }
}
