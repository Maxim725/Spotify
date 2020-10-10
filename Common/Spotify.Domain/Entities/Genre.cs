using Spotify.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс жанра музыки.
    /// </summary>
    public class Genre : NamedEntity
    {
        /// <value>
        /// Описание жанра.
        /// </value>
        public string Description { get; set; }

        /// <value>
        /// Количесво прослушиваний треков в данном жанре.
        /// Прослушивания обновляются один раз в рассчетный период, к примеру, раз в сутки.
        /// По умолчанию 0.
        /// </value>
        public ulong Plays { get; set; }
    }
}