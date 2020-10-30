using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities
{
    public class PlaylistTrack
    {
        public int TrackId { get; set; }
        public Track Track { get; set; }

        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
