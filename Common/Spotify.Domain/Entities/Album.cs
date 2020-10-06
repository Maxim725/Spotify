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
        public DateTime PublicationDate { get; set; }
        public IEnumerable<AuthorAlbum> Authors { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
        public Image Image { get; set; }
    }

    public class AuthorAlbum
    {
        public int Id { get; set; }
        public Album Album { get; set; }
        public Author Author { get; set; }

    }
}
