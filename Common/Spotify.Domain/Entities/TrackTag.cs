using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    /// <summary> Тэг для трека </summary>
    public class TrackTag : NamedEntity
    {
        /// <summary> Список классификаций тегов </summary>
        public IEnumerable<TagFamily> TagFamily { get; set; }
    }
}
