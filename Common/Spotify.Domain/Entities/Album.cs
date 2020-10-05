using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spotify.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Album : NamedEntity
    {
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public DateTime PublicationDate { get; set; }
        
        //TODO: Виртуальные методы для авторов и треков

        [ForeignKey(nameof(AuthorIds))]
        public virtual IEnumerable<Author> Authors { get; set; }

        [ForeignKey(nameof(TrackIds))]
        public virtual IEnumerable<Track> Tracks { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual Image Image { get; set; }
    }
}
