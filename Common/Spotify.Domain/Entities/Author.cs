using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Author : IdentityUser
    {
        public string Biography { get; set; }
        public string PathImage { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public IEnumerable<int> AlbumIds { get; set; }
        public DateTime CreationDate { get; set; }

        //TODO: Виртуальные методы Треков и Альбомов
        [ForeignKey(nameof(AlbumIds))]
        public virtual IEnumerable<Album> Albums { get; set; }
        [ForeignKey(nameof(TrackIds))]
        public virtual IEnumerable<Track> Tracks { get; set; }
    }
}
