using System;
using System.Collections.Generic;
using System.Text;
using Spotify.Domain.Entities.Intermediate;
using Spotify.Domain.Entities;
using Spotify.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections;
using Spotify.Domain.SpecialModels;

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

        public IEnumerable<Playlist> GetPlaylistsIdByUserId(int userId)
        {
            IEnumerable<Playlist> playlists = _db.UserPlaylist.Include(x => x.Playlist).Where(x => x.UserId.Equals(userId)).Select(x => x.Playlist);

            return playlists;
        }

        public IEnumerable<int> GetAlbumsIdByUserId(int userId)
        {
            IEnumerable<int> albums = _db.UserLikedAlbum.Where(x => x.UserId.Equals(userId)).Select(x => x.AlbumId);

            return albums;
        }
        public IEnumerable<int> GetPopularAlbumsId()
        {
            var popularAlbumsId = _db.Albums.Select(x => new { Id =x.AlbumId, Plays = x.Plays}).ToList();

            return popularAlbumsId.OrderBy(x => x.Plays).Select(x => x.Id).Take(12).ToHashSet();
        }
        public Album GetAlbumById(int albumId)
        {
            Album album = _db.Albums.Include(x => x.Tracks).ThenInclude(x => x.Track).Include(x => x.Authors).ThenInclude(x => x.Author).FirstOrDefault(x => x.AlbumId.Equals(albumId));

            return album;
        }

        


        public Author GetAuthorById(int id)
        {
            Author author = _db.Authors
                               .Include(x => x.Albums)
                               .Include(x => x.Tracks)
                               .FirstOrDefault(x => x.AuthorId.Equals(id));

            return author;
        }

        public IEnumerable<int> GetPopularAuthorAlbumsById(int authorId)
        {
            return _db.AlbumAuthor.Where(x => x.AuthorId.Equals(authorId)).Select(x => x.AlbumId);
        }
        public IEnumerable<Track> GetTracks(int albumId)
        {
            return _db.AlbumTrack.Where(x => x.AlbumId.Equals(albumId)).Include(x => x.Track).ThenInclude(x => x.Authors).ThenInclude(x => x.Author).Select(x => x.Track);
        }
        public IEnumerable<Track> GetPopularTracksByArtist(int authorId)
        {
            HashSet<Track> set = new HashSet<Track>();
            
            var groupTracks = _db.AlbumAuthor.Where(x => x.AuthorId.Equals(authorId)).Include(x => x.Album).ThenInclude(x => x.Tracks).ThenInclude(x => x.Track).Select( x=> x.Album.Tracks);
            
            foreach(var g in groupTracks)
            {
                foreach(var i in g)
                {
                    if(!set.Contains(i.Track))
                        set.Add(i.Track);
                }
            }

            return set;
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
        public IEnumerable<Author> GetAuthorsByTrackId(int trackId)
        {
            IEnumerable<int> authorsId = _db.TrackAuthor.Where(x => x.TrackId == trackId).Select(x => x.AuthorId);

            IEnumerable<Author> authors = _db.Authors.Where(x => authorsId.Contains(x.AuthorId));

            return authors;
        }
        public Album GetAlbumByTrackId(int trackId)
        {
            return _db.Tracks.Include(x =>x.Album).FirstOrDefault(x => x.TrackId.Equals(trackId)).Album;
        }


        // систему рекомендаций сюда дописать
        public IEnumerable<AlbumTrack> Recommendation(IEnumerable<int> tracksId)
        {
            //// Брать срез максимум из 50-ти треков
            //List<int> sliceTracksId = new List<int>();
            //for(int i = 0; i< tracksId.Count(); i++)
            //{
            //    if (i.Equals(50)) break;
            //    sliceTracksId.Add(tracksId.ElementAt(i));
            //}

            //// Массив самых популярных тегов (тег + количество повторений)
            //IEnumerable<int> trackTags = _db.TrackTag.Where(x => sliceTracksId.Contains(x.TrackId)).Select(x => x.TagId).ToList();
            //// var tagRepetitions = trackTags.GroupBy(x => x).Select(x =>  new { Id = x, CountId = x.Count() }).OrderBy(x => x.CountId);

            //// Массив массив обобщённых тегов (тег + количество повторений)

            //var templateTrackTags = _db.Tags.Where(x => trackTags.Contains(x.TagId)).GroupBy(x => x.FamilyId).Select(x => new { Id = x, CountId = x.Count() }).OrderBy(x => x.CountId).ToList();
            ////if (templateTrackTags.Count() > 3)
            ////    templateTrackTags = templateTrackTags.Take(3);



            //var tracks = new List<RecommendationModel>();
            //if (templateTrackTags.Count() == 0)
            //    return null;

            //var id = templateTrackTags.ElementAt(0).Id;

            //var trackTagsId = _db.Tags.Where(x => x.FamilyId.Equals(id)).Select(x=> x.TagId);

            //var recTracks = _db.TrackTag.Where(x => trackTagsId.Contains(x.TagId)).GroupBy(x => x.TrackId);

            //foreach(var track in recTracks)
            //{
            //    var idTrack = track.Key;
            //    int w = 0;
            //    foreach(var repT in track) {
            //        if (trackTagsId.Contains(repT.TagId)) w++;
            //    }
            //    tracks.Add(new RecommendationModel(idTrack, w));
            //}
            //tracks.OrderBy(x => x.Weight);


            //var result = _db.Tracks.Where(t => tracks/*.Take(50)*/.Select(x => x.Id).Contains(t.TrackId));
            //if (result.Count() > 50)
            //    result = result.Take(50);

            // Возникло множество проблем, надо будет алгоритм пилить (я не сильён в рекомендательных алгоритмах)
            var rand = new Random();
            int[] randId = new int[50];
            int countTracks = _db.Tracks.Count();
            if(countTracks > 50)
            {
                for(int i = 0; i < randId.Length; i++)
                {
                    int value = rand.Next(1, countTracks);
                    if (!randId.Contains(value))
                    {
                        randId[i] = value;
                    }
                    else
                    {
                        i--;
                        continue;
                    }
                }
                
            }
            else if(countTracks == 0)
            {
                return new List<AlbumTrack>();
            }
            else if(countTracks == 1)
            {
                randId[0] = _db.Tracks.First().TrackId;
            }
            else
            {
                for (int i = 0; i < randId.Length; i++)
                {
                    int value = rand.Next(1, countTracks);
                    randId[i] = value;
                }
            }
            var result = _db.AlbumTrack.Include(x => x.Track).ThenInclude(x => x.Authors).ThenInclude(x => x.Author).Include(x => x.Album);
			// .Include(x => x.Authors).ThenInclude(x => x.Author).Where(x => randId.Contains(x.TrackId));

            return result;
        }

        // Ненужные методы (удалить)
        public IEnumerable<Album> GetAlbumsByUserId(int userId)
        {
            IEnumerable<Album> albums = _db.UserLikedAlbum.Include(x => x.Album).Where(x => x.UserId.Equals(userId)).Select(x => x.Album);

            return albums;
        }
    }
}
