using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Identity;
using Spotify.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.DAL.Init
{
    /*
     * Сделать осмысленными тестовые данные или закомментировать их
     * Также переработать добавление пользователей (сейчас они без пароля)
     */
    public static class DbInitializer
    {
        public static void Initialize(SpotifyDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User {
                    UserName = "Polymusic", Email = "polymusic@test.com",
                    CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now,
                    Avatar = "", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var authors = new Author[]
            {
                new Author {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    Name = "Северный Флот",
                    Description = "«Северный Флот» — российская рок-группа. Основана музыкантами группы «Король и Шут» в 2013 году после смерти Михаила Горшенёва.",
                    Plays = 0,
                    Avatar = ""
                }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var albums = new Album[]
            {
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = DateTime.Parse("2016-03-1"),
                    Description = "«Мизантропия» — второй студийный альбом российской рок-группы «Северный Флот». Выпущен 1 марта 2016 года",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Мизантропия",
                    Plays = 0,
                    Cover = ""
                }
            };

            context.Albums.AddRange(albums);
            context.SaveChanges();

            var tracks = new Track[]
            {
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Поднимая знамя",
                    AlbumId = 1,
                    Duration = 2 * 60 + 43,
                    Plays = 0
                }
            };

            context.Tracks.AddRange(tracks);
            context.SaveChanges();

            var userLikedTrack = new UserLikedTrack[]
            {
                new UserLikedTrack {
                    UserId = 1,
                    TrackId = 1
                }
            };

            var trackAuthor = new TrackAuthor[]
            {
                new TrackAuthor {
                    AuthorId = 1,
                    TrackId = 1
                }
            };

            var albumAuthor = new AlbumAuthor[]
            {
                new AlbumAuthor {
                    AuthorId = 1,
                    AlbumId = 1
                }
            };

            context.UserLikedTrack.AddRange(userLikedTrack);
            context.TrackAuthor.AddRange(trackAuthor);
            context.AlbumAuthor.AddRange(albumAuthor);
            context.SaveChanges();
        }
    }
}
