using Microsoft.AspNetCore.Identity;
using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс автора музыки.
    /// </summary>
    public class Author : NamedEntity
    {
        /// <value>
        /// Статус подтверждения.
        /// По умолчанию <c>false</c>.
        /// Может быть изменен на <c>true</c> после модерации.
        /// </value>
        [Required(ErrorMessage = "Статус автора не указан.")]
        public bool Confirmed { get; set; }

        /// <value>
        /// Биография.
        /// Может быть пустой.
        /// </value>
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }

        /// <value>
        /// Дата создания странички автора.
        /// </value>
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата создания страницы автора не указана.")]
        public DateTime CreationDate { get; set; }

        /// <value>
        /// Список выпущенных альбомов.
        /// </value>
        public IEnumerable<AuthorAlbum> Albums { get; set; }

        /// <value>
        /// Фото (аватарка).
        /// Фото может и не быть.
        /// </value>
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        /// <value>
        /// Количесво прослушиваний треков данного автора.
        /// Прослушивания обновляются один раз в рассчетный период, к примеру, раз в сутки.
        /// По умолчанию 0.
        /// </value>
        [Required(ErrorMessage = "Количество прослушиваний автора не указано.")]
        public ulong Plays { get; set; }
    }
}
