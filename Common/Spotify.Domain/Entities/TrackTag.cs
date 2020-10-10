using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс тега трека.
    /// Теги используются для указания субъективной информации о треке.
    /// Например, "для сна", "осень".
    /// </summary>
    public class TrackTag : NamedEntity
    {
        /// <value>
        /// Семейство тегов.
        /// Теги формируют семейства. Это помогает улучшить подборки треков.
        /// Например, "грустный" и "веселый" принадлежат к семейству "настроение".
        /// </value>
        public IEnumerable<TagFamily> TagFamily { get; set; }
    }
}
