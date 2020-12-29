using Microsoft.EntityFrameworkCore;
using Spotify.DAL;
using Spotify.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        private class Model : IComparable<Model>
        {
            public string TrackName { get; set; }
            public int IdTrack { get; set; }
            public int Weight { get; set; } = 0;

            public int CompareTo(Model other)
            {
                if (other == null) return 1;

                else return this.Weight.CompareTo(other.Weight);
            }
        }

        public IEnumerable<Track> SearchTrack(string query)
        {
            List<Model> trackNames = _db.Tracks.Select(t => new Model { TrackName = t.Title + " - " + string.Concat(t.Authors.Select(t => t.Author.Name + " ")), IdTrack = t.TrackId }).ToList();


            for (int i = 0; i < trackNames.Count(); i++)
                trackNames[i].TrackName = Regex.Replace(trackNames[i].TrackName, @"/[\(\)]/gi", "");

            var queryWords = Regex.Replace(query.ToLower(), @"/[\(\)]/gi", "").Split(' ');

            foreach (Model trackName in trackNames)
            {
                for (int i = 0; i < trackName.TrackName.Length; i++) {
                    int w = 0;
                    var weightGroup = trackName.TrackName.Split(' ').Select((x) =>
                    {
                        foreach (var queryWord in queryWords)
                            return x.Contains(queryWord);


                        return false;
                    });

                    weightGroup.Select((x) =>
                    {
                        if (x == true) w++;
                        
                        return x;
                    });


                    trackName.Weight = w;
                
                }
            }

            trackNames.Sort();

            List<Track> tracks = new List<Track>();
            foreach(Model trackName in trackNames)
            {
                var item = _db.Tracks.FirstOrDefaultAsync(x => x.TrackId.Equals(trackName.IdTrack));
                if (item == null)
                    continue;
                else
                    tracks.Add(item.Result);
            }
            return tracks;

        }
    }
}
