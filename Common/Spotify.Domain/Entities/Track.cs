using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Track : NamedEntity
    {
        public string SoundPath { get; set; }
        public int? ImageId { get; set; }
        public TimeSpan Duration { get; set; }
        public int? AlbumId { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> TagIds { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
        public uint Auditions { get; set; }
        public DateTime UploadDate { get; set; }

        //TODO: Виртуальные методы для авторов и альбома

        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual Image Image { get; set; }
        
        [ForeignKey(nameof(AuthorIds))]
        public virtual IEnumerable<Author> Authors { get; set; }

        [ForeignKey(nameof(TagIds))]
        public virtual IEnumerable<TrackTag> Tags { get; set; }
        
        [ForeignKey(nameof(GenreIds))]
        public virtual IEnumerable<Genre> Genres { get; set; }

    }
}
