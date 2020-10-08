using Microsoft.AspNetCore.Identity;
using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary> Автор песен </summary>
    public class Author : NamedEntity
    {
        /// <summary> Подтверждённый ли автор </summary>
        public bool Confirmed { get; set; }

        /// <summary> Биография </summary>
        public string Biography { get; set; }

        /// <summary> Дата создание странички автора </summary>
        public DateTime CreationDate { get; set; }

        /// <summary> Список выпущенных альбомов </summary>
        public IEnumerable<AuthorAlbum> Albums { get; set; }

        /// <summary> Фото автора (аватарка) </summary>
        public Image Image { get; set; }
    }
}
