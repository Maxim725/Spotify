using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Confirmed { get; set; }
        public string Biography { get; set; }
        public int? ImageId { get; set; }
        public IEnumerable<int> AlbumIds { get; set; }
        public DateTime CreationDate { get; set; }

        //TODO: Виртуальные методы Треков и Альбомов

        [ForeignKey(nameof(AlbumIds))]
        public virtual IEnumerable<Album> Albums { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual Image Image { get; set; }
    }
}
