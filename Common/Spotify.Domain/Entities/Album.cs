using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary> Альбом с песнями </summary>
    public class Album : NamedEntity
    {
        /// <summary> Описание альбома </summary>
        public string Description { get; set; }

        /// <summary> Дата публикации </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary> Авторы альбома </summary>
        public IEnumerable<AuthorAlbum> Authors { get; set; }

        /// <summary> Список треков альбома </summary>
        public IEnumerable<Track> Tracks { get; set; }

        /// <summary> Картинка альбома </summary>
        public Image Image { get; set; }
    }
}
