using Microsoft.EntityFrameworkCore;
using Spotify.DAL;
using Spotify.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Services
{
    public sealed class SearchService
    {
        private readonly SpotifyDbContext _db;
        public SearchService(SpotifyDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Track> GetUserTracksByName(int id, string name)
        {
            // TODO: тут можно по-другому сделать, через временную коллекцию, которая будет содержать отфильтрованный список, 
            //       на основе треков пользователя (если такое возможно)
            var tracks = _db.UserLikedTrack
                            .Include(x => x.Track)
                            .Include(x => x.User)
                            .Where(x => x.UserId.Equals(id) && x.Track.Title.Contains(name))
                            .Select(x => x.Track);
            return tracks;
        }
        public IEnumerable<Author> GetAuthorsByName(string name)
        {
            var authors = _db.Authors
                            .Where(x => x.Name.Contains(name));

            return authors;
        }
        public IEnumerable<Track> GetTracksByName(string name)
        {
            var tracks = _db.Tracks.Where(x => x.Title.Contains(name));

            return tracks;
        }
        public IEnumerable<Album> GetPlaylistsByName(string name)
        {
            var albums = _db.Albums.Where(x => x.Title.Contains(name));
            return albums;
        }
        
    }
}
