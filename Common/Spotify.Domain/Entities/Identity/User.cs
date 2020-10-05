﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public IEnumerable<int> FollowPlaylistIds { get; set; }
        public IEnumerable<int> FollowAuthorIds { get; set; }
        public IEnumerable<int> FollowTrackIds { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(FollowPlaylistIds))]
        public virtual IEnumerable<Playlist> Playlists { get; set; }

        [ForeignKey(nameof(FollowAuthorIds))]
        public virtual IEnumerable<Author> Authors { get; set; }

        [ForeignKey(nameof(FollowTrackIds))]
        public virtual IEnumerable<Track> Tracks { get; set; }
    }
}
