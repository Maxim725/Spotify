using System;
using System.Collections.Generic;
using System.Text;
using Spotify.Domain.Entities;

namespace Spotify.DAL
{
    public interface ITrackListProvider
    {
        IEnumerable<Track> getTracks(SpotifyDbContext context);
    }
}
