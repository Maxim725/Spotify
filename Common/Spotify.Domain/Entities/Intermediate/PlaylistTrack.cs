using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities.Intermediate
{
    public class PlaylistTrack
    {
        public int PlaylistId { get; set; }

        public Playlist Playlist { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }
    }
}
