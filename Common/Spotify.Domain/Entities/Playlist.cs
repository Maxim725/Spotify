using Spotify.Domain.Entities.Base;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Playlist : NamedEntity
    {
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        //TODO: Виртуальный метод для треков

        [ForeignKey(nameof(TrackIds))]
        public virtual IEnumerable<Track> Tracks { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual Image Image { get; set; }
    }
}
