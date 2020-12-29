using System;
using System.Collections.Generic;
using System.Text;
using Spotify.Domain.Entities.Intermediate;
using Spotify.Domain.Entities;
using Spotify.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Services
{
    public sealed class SelectionService
    {
        private readonly SpotifyDbContext _db;
        public SelectionService(SpotifyDbContext db)
        {
            _db = db;
        }

        public IEnumerable<UserLikedTrack> GetUserLikedTracks(int id)
        {
            IEnumerable<UserLikedTrack> tracks = _db.UserLikedTrack
                                                    .Include(x => x.Track)
                                                    .Include(x => x.User)
                                                    .Where(x => x.UserId.Equals(id));
            if (tracks is null)
            {
                return Enumerable.Empty<UserLikedTrack>();
            }
            else
            {
                return tracks;
            }
        }
        public IEnumerable<UserLikedAuthor> GetUserLikedAuthors(int id)
        {
            IEnumerable<UserLikedAuthor> authors = _db.UserLikedAuthor
                                                       .Include(x => x.User)
                                                       .Include(x => x.Author)
                                                       .Where(x => x.UserId.Equals(id));
            if (authors is null)
            {
                return Enumerable.Empty<UserLikedAuthor>();
            }
            else
            {
                return authors;
            }
        }
        public IEnumerable<UserPlaylist> GetUserPlaylists(int id)
        {
            IEnumerable<UserPlaylist> playlists = _db.UserPlaylist
                                                     .Include(x => x.Playlist)
                                                     .Include(x => x.User)
                                                     .Where(x => x.UserId.Equals(id));
            if (playlists is null)
            {
                return Enumerable.Empty<UserPlaylist>();
            }
            else
            {
                return playlists;
            }
        }
        public Author GetAuthorById(int id)
        {
            Author author = _db.Authors
                               .Include(x => x.Albums)
                               .Include(x => x.Tracks)
                               .FirstOrDefault(x => x.AuthorId.Equals(id));

            return author;
        }
        public Playlist GetPlaylistById(int id)
        {
            Playlist playlist = _db.Playlists
                                   .Include(x => x.Tracks)
                                   .Include(x => x.CreatedBy)
                                   .FirstOrDefault(x => x.PlaylistId.Equals(id));
            return playlist;
        }
        public Track GetTrackById(int id)
        {
            Track track = _db.Tracks
                             .Include(x => x.Album)
                             .Include(x => x.CreatedBy)
                             .FirstOrDefault(x => x.TrackId.Equals(id));
            return track;
        }

        // систему рекомендаций сюда дописать


    }
}
