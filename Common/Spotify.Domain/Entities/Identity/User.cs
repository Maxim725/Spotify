using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public IEnumerable<int> PlaylistIds { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(PlaylistIds))]
        public virtual IEnumerable<Playlist> Playlists { get; set; }

        [ForeignKey(nameof(AuthorIds))]
        public virtual IEnumerable<Author> Authors { get; set; }

        [ForeignKey(nameof(TrackIds))]
        public virtual IEnumerable<Track> Tracks { get; set; }
    }
}
