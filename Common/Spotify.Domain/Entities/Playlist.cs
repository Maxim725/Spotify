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
        public string PathImages { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        //TODO: Виртуальный метод для треков

        [ForeignKey(nameof(TrackIds))]
        public virtual IEnumerable<Track> Tracks { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
