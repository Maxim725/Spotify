using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class TagTrackTag
    {
        public int TagId { get; set; }
        public int TrackId { get; set; }

        public Track Track { get; set; }
        public TrackTag Tag { get; set; }
    }
}
