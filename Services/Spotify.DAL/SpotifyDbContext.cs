using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.DAL
{
    public class SpotifyDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Author> Authros { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<TrackTag> TrackTags { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<TagFamily> TagFamilies { get; set; }

        public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options) 
            : base(options)
        {
        }
    }
}
