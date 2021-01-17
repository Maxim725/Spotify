﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Identity;
using Spotify.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.IO;
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
                    Avatar = "Spotify/User/polyMusic.jpg", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                },
                new User {
                    UserName = "12dot", Email = "12dot@mail.ru",
                    CreatedOn = new DateTime(2011, 6, 10), UpdatedOn = DateTime.Now,
                    Avatar = "Spotify/User/12dot.jpg", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                },
                new User {
                    UserName = "David", Email = "David@mail.ru",
                    CreatedOn = new DateTime(2020, 6, 10), UpdatedOn = DateTime.Now,
                    Avatar = "Spotify/User/David.jpg", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                },
                new User {
                    UserName = "Nekit", Email = "Nekit@mail.ru",
                    CreatedOn = new DateTime(2020, 7, 10), UpdatedOn = DateTime.Now,
                    Avatar = "Spotify/User/Nekit.jpg", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                },
                new User {
                    UserName = "Ilya", Email = "Ilya@gmail.com",
                    CreatedOn = new DateTime(2019, 3, 14), UpdatedOn = DateTime.Now,
                    Avatar = "Spotify/User/Ilya.jpg", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                },
                new User {
                    UserName = "Masha", Email = "Masha777@mail.ru",
                    CreatedOn = new DateTime(2013, 3, 10), UpdatedOn = DateTime.Now,
                    Avatar = "Spotify/User/Masha.jpg", LikedAuthors = new List<UserLikedAuthor>(),
                    LikedTracks = new List<UserLikedTrack>(),
                    Subscriptions = new List<UserSubscription>(),
                    LikedAlbums = new List<UserLikedAlbum>(),
                    Playlists = new List<UserPlaylist>()
                },
                new User {
                    UserName = "Katya", Email = "KatyaBog@rambler.com",
                    CreatedOn = new DateTime(2020, 02, 20), UpdatedOn = DateTime.Now,
                    Avatar = "Spotify/User/Katya.jpg", LikedAuthors = new List<UserLikedAuthor>(),
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
                    Avatar = "Spotify/Author/Северный_Флот/Северный_Флот.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2017, 5, 24),
                    UpdatedOn = DateTime.Now,
                    Name = "Obladaet",
                    Description = "«Obladaet» - Мечта любой школьницы. Король русского трилла.",
                    Plays = 4,
                    Avatar = "Spotify/Author/Obladaet/Obladaet.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2012, 5, 21),
                    UpdatedOn = DateTime.Now,
                    Name = "Хаски",
                    Description = "Хаски это не порода собак в данном случае. Это Есенин 21 века по тексту, Дафт панк на старте по звучанию",
                    Plays = 3,
                    Avatar = "Spotify/Author/Хаски/Хаски.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2010, 2, 11),
                    UpdatedOn = DateTime.Now,
                    Name = "Travis Scott",
                    Description = "«Travis Scott» - Король.",
                    Plays = 65654,
                    Avatar = "Spotify/Author/Travis_Scott/Travis_Scott.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2017, 5, 24),
                    UpdatedOn = DateTime.Now,
                    Name = "Gorillaz",
                    Description = "Gorillaz это вам не обезьянки. Экспериментальный фанк рок с мультяшками!",
                    Plays = 43432,
                    Avatar = "Spotify/Author/Gorillaz/Gorillaz.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2020, 3, 19),
                    UpdatedOn = new DateTime(2020, 4, 24),
                    Name = "Drake",
                    Description = "Drake - главный живой хитмейкер всго мира.",
                    Plays = 656,
                    Avatar = "Spotify/Author/Drake/Drake.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2017, 5, 24),
                    UpdatedOn = DateTime.Now,
                    Name = "Kanye West",
                    Description = "Уверовал и поехала башка",
                    Plays = 400,
                    Avatar = "Spotify/Author/Kanye_West/Kanye_West.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2019, 2, 14),
                    UpdatedOn = DateTime.Now,
                    Name = "Daft Punk",
                    Description = "Legends.",
                    Plays = 76575,
                    Avatar = "Spotify/Author/Daft_Punk/Daft_Punk.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2020, 3, 11),
                    UpdatedOn = DateTime.Now,
                    Name = "Kizaru",
                    Description = "Чел из розыска интерпола на свободе один из самых популярных реперов СНГ.",
                    Plays = 432432,
                    Avatar = "Spotify/Author/Kizaru/Kizaru.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2018, 2, 14),
                    UpdatedOn = DateTime.Now,
                    Name = "Joji",
                    Description = "Pink guy, I'm gay, Genius artist.",
                    Plays = 443243,
                    Avatar = "Spotify/Author/Joji/Joji.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2014, 3, 4),
                    UpdatedOn = DateTime.Now,
                    Name = "Saluki",
                    Description = "Saliku - бывший битмейкер, крутой репер.",
                    Plays = 454,
                    Avatar = "Spotify/Author/Saluki/Saluki.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2013, 2, 1),
                    UpdatedOn = DateTime.Now,
                    Name = "Morgenstern",
                    Description = "",
                    Plays = 777,
                    Avatar = "Spotify/Author/Morgenstern/Morgenstern.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2018, 3, 15),
                    UpdatedOn = DateTime.Now,
                    Name = "Pharaoh",
                    Description = "СкрСкрСкр.",
                    Plays = 43232,
                    Avatar = "Spotify/Author/Pharaoh/Pharaoh.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2012, 1, 3),
                    UpdatedOn = DateTime.Now,
                    Name = "Asap Rocky",
                    Description = "Раким секс идол мира хип хопа.",
                    Plays = 4432,
                    Avatar = "Spotify/Author/Asap_Rocky/Asap_Rocky.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2020, 2, 13),
                    UpdatedOn = DateTime.Now,
                    Name = "Justin Bieber",
                    Description = "Justin Bieber is a Baby, baby, Baby oooooooh...",
                    Plays = 54534,
                    Avatar = "Spotify/Author/Justin_Bieber/Justin_Bieber.jpg"
                },
                new Author {
                    CreatedOn = new DateTime(2017, 5, 22),
                    UpdatedOn = DateTime.Now,
                    Name = "Schoolboy Q",
                    Description = "Мальчик з школы вышел",
                    Plays = 44323,
                    Avatar = "Spotify/Author/Schoolboy_Q/Schoolboy_Q.jpg"
                }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();


            var playlists = new Playlist[]
            {
                new Playlist{
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = DateTime.Now,
                    Title = "Melanholy",
                    Description = "When you need to some chill",
                    Plays = 2312,
                    Tracks = new List<PlaylistTrack>()
                },
                new Playlist{
                    CreatedOn = DateTime.Now,
                    CreatedById = 2,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = DateTime.Now,
                    Title = "Party Hard",
                    Description = "For the late night with friends",
                    Plays = 2312,
                    Tracks = new List<PlaylistTrack>(),
                },
                new Playlist{
                    CreatedOn = DateTime.Now,
                    CreatedById = 3,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = DateTime.Now,
                    Title = "Workout",
                    Description = "Go to the gym and turn it on",
                    Plays = 2312,
                    Tracks = new List<PlaylistTrack>(),
                }
            };

            context.Playlists.AddRange(playlists);
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
                    Cover = "/data/album-cover/1"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2020, 3, 19),
                    Description = "Самый хитовый альбом десятилетия.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Scorpion",
                    Plays = 23,
                    Cover = "Spotify/Author/Drake/Albums/Scorpion/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2020, 4, 9),
                    Description = "Cozy Tapes - сборник всех с ASAP mob",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Cozy Tapes",
                    Plays = 23,
                    Cover = "Spotify/Author/Asap_Rocky/Albums/Cozy_Tapes/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2020, 1, 8),
                    Description = "Дебютный альбом артиста, благодаря которому приобрел начальную известность",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "DOUBLE TAP",
                    Plays = 2343,
                    Cover = "Spotify/Author/Obladaet/Albums/DOUBLE_TAP/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2018, 5, 7),
                    Description = "С него началась популярность артиста.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 2,
                    Title = "Mas Fuerte",
                    Plays = 2323,
                    Cover = "Spotify/Author/Kizaru/Albums/Mas_Fuerte/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2015, 11, 7),
                    Description = "Самый хитовый альбом десятилетия.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Любимые песни (воображаемых) людей",
                    Plays = 65443,
                    Cover = "Spotify/Author/Хаски/Albums/Любимые_песни_(воображаемых)_людей/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2010, 3, 11),
                    Description = "Самый хитовый альбом десятилетия.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Легендарная пыль",
                    Plays = 24543,
                    Cover = "Spotify/Author/Morgenstern/Albums/Легендарная_пыль/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2015, 3, 19),
                    Description = "PHLORA - дебютный альбом артиста в новом жанре.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "PHLORA",
                    Plays = 22143,
                    Cover = "Spotify/Author/Pharaoh/Albums/PHLORA/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2018, 5, 13),
                    Description = "В честь этого альбома названа первая коллекция одежды артиста, ставшая легендарной.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Yeezus",
                    Plays = 2543,
                    Cover = "Spotify/Author/Kanye_West/Albums/Yeezus/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2018, 2, 16),
                    Description = "Дни демонов",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Demon Days",
                    Plays = 5433,
                    Cover = "Spotify/Author/Gorillaz/Albums/Demon_Days/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2018, 2, 16),
                    Description = "",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Nectar",
                    Plays = 433,
                    Cover = "Spotify/Author/Gorillaz/Albums/Demon_Days/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2019, 7, 23),
                    Description = "Парни в космических шлемах дома забабахали всемирноизвестный альбом.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Homework",
                    Plays = 113,
                    Cover = "Spotify/Author/Daft_Punk/Albums/Homework/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2013, 5, 21),
                    Description = "Лучший альбом по мнению одного из разработчиков сервиса.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Beibs In The Trap",
                    Plays = 16743233,
                    Cover = "Spotify/Author/Travis_Scott/Albums/Beibs_In_The_Trap/Cover.jpg"
                },
                new Album {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    PublishedOn = new DateTime(2013, 5, 24),
                    Description = "14-летний мальчик выпускает альбом мирового уровня.",
                    Authors = new List<AlbumAuthor>(),
                    CreatedById = 1,
                    Title = "Babies",
                    Plays = 167433,
                    Cover = "Spotify/Author/Justin_Bieber/Albums/Babies/Cover.jpg"
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
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Cadillac",
                    AlbumId = 7,
                    Duration = 2 * 60 + 3,
                    Plays = 432
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Nonstop",
                    AlbumId = 2,
                    Duration = 2 * 60 - 3,
                    Plays = 432
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Around the world",
                    AlbumId = 12,
                    Duration = 2 * 60 - 13,
                    Plays = 5434
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Goosebumps",
                    AlbumId = 13,
                    Duration = 2 * 60 + 13,
                    Plays = 432
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Feel Good Inc.",
                    AlbumId = 10,
                    Duration = 3 * 60,
                    Plays = 432
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Hold My Liqour",
                    AlbumId = 9,
                    Duration = 2 * 60 - 17,
                    Plays = 234
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Оу Щит",
                    AlbumId = 5,
                    Duration = 2 * 60 - 14,
                    Plays = 332
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Double Tap",
                    AlbumId = 4,
                    Duration = 2 * 60 - 43,
                    Plays = 112
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Baby",
                    AlbumId = 14,
                    Duration = 2 * 60 + 12,
                    Plays = 542
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "Панелька",
                    AlbumId = 6,
                    Duration = 2 * 60 + 3,
                    Plays = 1234
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "NITROUS",
                    AlbumId = 11,
                    Duration = 2 * 60 - 14,
                    Plays = 532
                },
                new Track {
                    CreatedOn = DateTime.Now,
                    CreatedById = 1,
                    Title = "sdp",
                    AlbumId = 13,
                    Duration = 2 * 60 - 11,
                    Plays = 132
                }
                
            };

            context.Tracks.AddRange(tracks);
            context.SaveChanges();


            var genres = new Genre[]
            {
             new Genre{
                 Description = "Рок",
                 Plays = 54543
             },
             new Genre{
                 Description = "Хип-хоп",
                 Plays = 323131
             },
             new Genre{
                 Description = "Джаз",
                 Plays = 545435
             },
             new Genre{
                 Description = "Поп-музыка",
                 Plays = 323123
             },
             new Genre{
                 Description = "Блюз",
                 Plays = 534534
             },
             new Genre{
                 Description = "Электронная музыка",
                 Plays = 342324
             },
             new Genre{
                 Description = "Шансон",
                 Plays = 43433
             }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();

            var trackGenre = new TrackGenre[]
            {
                new TrackGenre {
                    TrackId = 1,
                    GenreId = 1
                },
                new TrackGenre {
                    TrackId = 2,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 3,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 4,
                    GenreId = 3
                },
                new TrackGenre {
                    TrackId = 5,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 6,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 7,
                    GenreId = 4
                },
                new TrackGenre {
                    TrackId = 8,
                    GenreId = 1
                },
                new TrackGenre {
                    TrackId = 9,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 10,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 11,
                    GenreId = 2
                },
                new TrackGenre {
                    TrackId = 12,
                    GenreId = 6
                },
                new TrackGenre {
                    TrackId = 13,
                    GenreId = 7
                }
            };

            var albumTrack = new AlbumTrack[]
            {
                new AlbumTrack {
                    AlbumId = 1,
                    TrackId = 1
                },
                new AlbumTrack {
                    AlbumId = 7,
                    TrackId = 2
                },
                new AlbumTrack {
                    AlbumId = 2,
                    TrackId = 3
                },
                new AlbumTrack {
                    AlbumId = 12,
                    TrackId = 4
                },
                new AlbumTrack {
                    AlbumId = 13,
                    TrackId = 5
                },
                new AlbumTrack {
                    AlbumId = 10,
                    TrackId = 6
                },
                new AlbumTrack {
                    AlbumId = 9,
                    TrackId = 7
                },
                new AlbumTrack {
                    AlbumId = 5,
                    TrackId = 8
                },
                new AlbumTrack {
                    AlbumId = 4,
                    TrackId = 9
                },
                new AlbumTrack {
                    AlbumId = 14,
                    TrackId = 10
                },
                new AlbumTrack {
                    AlbumId = 6,
                    TrackId = 11
                },
                new AlbumTrack {
                    AlbumId = 11,
                    TrackId = 12
                },
                new AlbumTrack {
                    AlbumId = 13,
                    TrackId = 13
                }
            };

            var userLikedTrack = new UserLikedTrack[]
            {
                new UserLikedTrack {
                    UserId = 1,
                    TrackId = 1
                },
                new UserLikedTrack {
                    UserId = 2,
                    TrackId = 3
                },
                new UserLikedTrack {
                    UserId = 2,
                    TrackId = 13
                },
                new UserLikedTrack {
                    UserId = 2,
                    TrackId = 5
                },
                new UserLikedTrack {
                    UserId = 2,
                    TrackId = 2
                },
                new UserLikedTrack {
                    UserId = 3,
                    TrackId = 5
                },
                new UserLikedTrack {
                    UserId = 3,
                    TrackId = 6
                },
                new UserLikedTrack {
                    UserId = 4,
                    TrackId = 12
                },
                new UserLikedTrack {
                    UserId = 5,
                    TrackId = 8
                },
                new UserLikedTrack {
                    UserId = 5,
                    TrackId = 9
                },
                new UserLikedTrack {
                    UserId = 5,
                    TrackId = 10
                },
                new UserLikedTrack {
                    UserId = 6,
                    TrackId = 4
                },
                new UserLikedTrack {
                    UserId = 6,
                    TrackId = 1
                },
                new UserLikedTrack {
                    UserId = 7,
                    TrackId = 11
                }
            };

            var trackAuthor = new TrackAuthor[]
            {
                new TrackAuthor {
                    AuthorId = 1,
                    TrackId = 1
                },
                new TrackAuthor {
                    AuthorId = 12,
                    TrackId = 2
                },
                new TrackAuthor {
                    AuthorId = 6,
                    TrackId = 3
                },
                new TrackAuthor {
                    AuthorId = 8,
                    TrackId = 4
                },
                new TrackAuthor {
                    AuthorId = 4,
                    TrackId = 5
                },
                new TrackAuthor {
                    AuthorId = 5,
                    TrackId = 6
                },
                new TrackAuthor {
                    AuthorId = 7,
                    TrackId = 7
                },
                new TrackAuthor {
                    AuthorId = 9,
                    TrackId = 8
                },
                new TrackAuthor {
                    AuthorId = 3,
                    TrackId = 9
                },
                new TrackAuthor {
                    AuthorId = 15,
                    TrackId = 10
                },
                new TrackAuthor {
                    AuthorId = 3,
                    TrackId = 11
                },
                new TrackAuthor {
                    AuthorId = 11,
                    TrackId = 12
                },
                new TrackAuthor {
                    AuthorId = 4,
                    TrackId = 13
                }
            };

            var playlistTrack = new PlaylistTrack[]
            {
                new PlaylistTrack{
                    PlaylistId = 1,
                    TrackId = 1
                },
                new PlaylistTrack{
                    PlaylistId = 1,
                    TrackId = 2
                },
                new PlaylistTrack{
                    PlaylistId = 1,
                    TrackId = 3
                },
                new PlaylistTrack{
                    PlaylistId = 1,
                    TrackId = 4
                },
                new PlaylistTrack{
                    PlaylistId = 2,
                    TrackId = 5
                },
                new PlaylistTrack{
                    PlaylistId = 3,
                    TrackId = 6
                },
                new PlaylistTrack{
                    PlaylistId = 2,
                    TrackId = 7
                },
                new PlaylistTrack{
                    PlaylistId = 3,
                    TrackId = 9
                },
                new PlaylistTrack{
                    PlaylistId = 3,
                    TrackId = 10
                },
                new PlaylistTrack{
                    PlaylistId = 3,
                    TrackId = 11
                },
                new PlaylistTrack{
                    PlaylistId = 3,
                    TrackId = 12
                },
            };

            var albumAuthor = new AlbumAuthor[]
            {
                new AlbumAuthor {
                    AuthorId = 1,
                    AlbumId = 1
                },
                new AlbumAuthor {
                    AuthorId = 2,
                    AlbumId = 4
                },
                new AlbumAuthor {
                    AuthorId = 3,
                    AlbumId = 6
                },
                new AlbumAuthor {
                    AuthorId = 4,
                    AlbumId = 13
                },
                new AlbumAuthor {
                    AuthorId = 5,
                    AlbumId = 10
                },
                new AlbumAuthor {
                    AuthorId = 6,
                    AlbumId = 2
                },
                new AlbumAuthor {
                    AuthorId = 7,
                    AlbumId = 9
                },
                new AlbumAuthor {
                    AuthorId = 8,
                    AlbumId = 12
                },
                new AlbumAuthor {
                    AuthorId = 9,
                    AlbumId = 5
                },
                new AlbumAuthor {
                    AuthorId = 10,
                    AlbumId = 11
                },
                new AlbumAuthor {
                    AuthorId = 12,
                    AlbumId = 7
                },
                new AlbumAuthor {
                    AuthorId = 13,
                    AlbumId = 8
                },
                new AlbumAuthor {
                    AuthorId = 14,
                    AlbumId = 3
                },
                new AlbumAuthor {
                    AuthorId = 15,
                    AlbumId = 14
                }
            };

            context.PlaylistTrack.AddRange(playlistTrack);
            context.TrackGenre.AddRange(trackGenre);
            context.AlbumTrack.AddRange(albumTrack);
            context.UserLikedTrack.AddRange(userLikedTrack);
            context.TrackAuthor.AddRange(trackAuthor);
            context.AlbumAuthor.AddRange(albumAuthor);
            context.SaveChanges();

           
        }

        public static void GetCustomUser(UserManager<User> _userManager, SignInManager<User> _signInManager, SpotifyDbContext _context)
        {
            if (_context.Users.FirstOrDefault(x => x.UserName.Equals("Test_User")) != null)
                return;

            var user = new User
            {
                UserName = "Test_User",
                Email = "testuser@rambler.com",
                CreatedOn = new DateTime(2020, 02, 20),
                UpdatedOn = DateTime.Now,
                Avatar = "Spotify/User/Test_User.jpg",
                LikedAuthors = new List<UserLikedAuthor>(),
                LikedTracks = new List<UserLikedTrack>(),
                Subscriptions = new List<UserSubscription>(),
                LikedAlbums = new List<UserLikedAlbum>(),
                Playlists = new List<UserPlaylist>()
            };
            string passw = "qweqwe";

            var result = _userManager.CreateAsync(user, passw).Result;
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach(var err in result.Errors)
                {
                    sb.Append(err.Description);
                    sb.Append(" ");
                }

                throw new Exception(sb.ToString());
            }

            int userId = int.Parse(_signInManager.UserManager.GetUserIdAsync(user).Result);

            var testUserPlaylists = new UserPlaylist[]
            {
                new UserPlaylist
                {
                    UserId = userId,
                    PlaylistId = 1
                },

                new UserPlaylist
                {
                    UserId = userId,
                    PlaylistId = 2
                },

                new UserPlaylist
                {
                    UserId = userId,
                    PlaylistId = 3
                }
            };

            _context.UserPlaylist.AddRange(testUserPlaylists);
            _context.SaveChanges();
        }

        public static void WriteFiles(IFileStorage<int> fb)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Author\\11\\11.jpg");

            fb.StoreFile(FileStorageFileType.AlbumCover, 1, File.ReadAllBytes(path), "img/jpeg");

            //TODO

            // 1) Северный флот не 1-й id
            // 2) Почмотреть как заполняются все альбомы + треки + User
            // 3) Синхронизировать id сущностей и файлов..

        }
    }
}
