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

        public TimeSpan Duration { get; set; }

        public uint Auditions { get; set; }

        public DateTime UploadDate { get; set; }

        public Album Album { get; set; }

        public Image Image { get; set; }

        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<TrackTag> Tags { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

    }
}
