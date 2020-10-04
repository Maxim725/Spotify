using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Track : NamedEntity
    {
        public string PathMp3 { get; set; }
        public string PathImage { get; set; }
        public TimeSpan PlayingTime { get; set; }
        public int? AlbumId { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public uint Auditions { get; set; }
        public DateTime UploadDate { get; set; }

        //TODO: Виртуальные методы для авторов и альбома
        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; }
        [ForeignKey(nameof(AuthorIds))]
        public virtual IEnumerable<Author> Authors { get; set; }
    }
}
