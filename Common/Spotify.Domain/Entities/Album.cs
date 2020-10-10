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
    public class Album : Playlist
    {
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
        public IEnumerable<AuthorAlbum> Authors { get; set; }

        /// <value>
        /// Обложка альбома.
        /// </value>
        public string Cover { get; set; }
    }
}
