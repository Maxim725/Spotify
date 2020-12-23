using Spotify.Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.DAL
{
    public class TrackListProviderTest : ITrackListProvider
    {
        public IEnumerable<Track> getTracks(SpotifyDbContext context)
        {
            List<Track> tracks = context.Tracks.ToList<Track>();
            tracks = tracks.FindAll(x => x.TrackId <= 10);

            return tracks;
        }
    }
}
