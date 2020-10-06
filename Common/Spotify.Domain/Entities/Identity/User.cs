using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spotify.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public DateTime CreationDate { get; set; }

        public IEnumerable<Playlist> Playlists { get; set; }

        public IEnumerable<Author> Authors { get; set; }


        public IEnumerable<Track> Tracks { get; set; }
    }
}
