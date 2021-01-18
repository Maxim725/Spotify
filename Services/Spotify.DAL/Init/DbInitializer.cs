using Microsoft.AspNetCore.Identity;
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
						  Avatar = "/data/author-avatar/1"
					 },
					 new Author {
						  CreatedOn = new DateTime(2017, 5, 24),
						  UpdatedOn = DateTime.Now,
						  Name = "Obladaet",
						  Description = "«Obladaet» - Мечта любой школьницы. Король русского трилла.",
						  Plays = 4,
						  Avatar = "/data/author-avatar/4"
					 },
					 new Author {
						  CreatedOn = new DateTime(2012, 5, 21),
						  UpdatedOn = DateTime.Now,
						  Name = "Хаски",
						  Description = "Хаски это не порода собак в данном случае. Это Есенин 21 века по тексту, Дафт панк на старте по звучанию",
						  Plays = 3,
						  Avatar = "/data/author-avatar/6"
					 },
					 new Author {
						  CreatedOn = new DateTime(2010, 2, 11),
						  UpdatedOn = DateTime.Now,
						  Name = "Travis Scott",
						  Description = "«Travis Scott» - Король.",
						  Plays = 65654,
						  Avatar = "/data/author-avatar/13"
					 },
					 new Author {
						  CreatedOn = new DateTime(2017, 5, 24),
						  UpdatedOn = DateTime.Now,
						  Name = "Gorillaz",
						  Description = "Gorillaz это вам не обезьянки. Экспериментальный фанк рок с мультяшками!",
						  Plays = 43432,
						  Avatar = "/data/author-avatar/10"
					 },
					 new Author {
						  CreatedOn = new DateTime(2020, 3, 19),
						  UpdatedOn = new DateTime(2020, 4, 24),
						  Name = "Drake",
						  Description = "Drake - главный живой хитмейкер всго мира.",
						  Plays = 656,
						  Avatar = "/data/author-avatar/2"
					 },
					 new Author {
						  CreatedOn = new DateTime(2017, 5, 24),
						  UpdatedOn = DateTime.Now,
						  Name = "Kanye West",
						  Description = "Уверовал и поехала башка",
						  Plays = 400,
						  Avatar = "/data/author-avatar/9"
					 },
					 new Author {
						  CreatedOn = new DateTime(2019, 2, 14),
						  UpdatedOn = DateTime.Now,
						  Name = "Daft Punk",
						  Description = "Legends.",
						  Plays = 76575,
						  Avatar = "/data/author-avatar/12"
					 },
					 new Author {
						  CreatedOn = new DateTime(2020, 3, 11),
						  UpdatedOn = DateTime.Now,
						  Name = "Kizaru",
						  Description = "Чел из розыска интерпола на свободе один из самых популярных реперов СНГ.",
						  Plays = 432432,
						  Avatar = "/data/author-avatar/5"
					 },
					 new Author {
						  CreatedOn = new DateTime(2018, 2, 14),
						  UpdatedOn = DateTime.Now,
						  Name = "Joji",
						  Description = "Pink guy, I'm gay, Genius artist.",
						  Plays = 443243,
						  Avatar = "/data/author-avatar/11"
					 },
					 new Author {
						  CreatedOn = new DateTime(2014, 3, 4),
						  UpdatedOn = DateTime.Now,
						  Name = "Saluki",
						  Description = "Saliku - бывший битмейкер, крутой репер.",
						  Plays = 454,
						  Avatar = "/data/author-avatar/15"
					 },
					 new Author {
						  CreatedOn = new DateTime(2013, 2, 1),
						  UpdatedOn = DateTime.Now,
						  Name = "Morgenstern",
						  Description = "",
						  Plays = 777,
						  Avatar = "/data/author-avatar/7"
					 },
					 new Author {
						  CreatedOn = new DateTime(2018, 3, 15),
						  UpdatedOn = DateTime.Now,
						  Name = "Pharaoh",
						  Description = "СкрСкрСкр.",
						  Plays = 43232,
						  Avatar = "/data/author-avatar/8"
					 },
					 new Author {
						  CreatedOn = new DateTime(2012, 1, 3),
						  UpdatedOn = DateTime.Now,
						  Name = "Asap Rocky",
						  Description = "Раким секс идол мира хип хопа.",
						  Plays = 4432,
						  Avatar = "/data/author-avatar/3"
					 },
					 new Author {
						  CreatedOn = new DateTime(2020, 2, 13),
						  UpdatedOn = DateTime.Now,
						  Name = "Justin Bieber",
						  Description = "Justin Bieber is a Baby, baby, Baby oooooooh...",
						  Plays = 54534,
						  Avatar = "/data/author-avatar/14"
					 },
					 new Author {
						  CreatedOn = new DateTime(2017, 5, 22),
						  UpdatedOn = DateTime.Now,
						  Name = "Schoolboy Q",
						  Description = "Мальчик з школы вышел",
						  Plays = 44323,
						  Avatar = "/data/author-avatar/16"
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
						  Cover = "/data/album-cover/2"
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
						  Cover = "/data/album-cover/3"
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
						  Cover = "/data/album-cover/4"
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
						  Cover = "/data/album-cover/5"
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
						  Cover = "/data/album-cover/6"
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
						  Cover = "/data/album-cover/7"
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
						  Cover = "/data/album-cover/8"
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
						  Cover = "/data/album-cover/9"
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
						  Cover = "/data/album-cover/10"
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
						  Cover = "/data/album-cover/11"
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
						  Cover = "/data/album-cover/12"
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
						  Cover = "/data/album-cover/13"
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
						  Cover = "/data/album-cover/14"
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
						  Track = tracks[0],
						  Genre = genres[0]
					 },
					 new TrackGenre {
						  Track = tracks[1],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[2],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[3],
						  Genre = genres[2]
					 },
					 new TrackGenre {
						  Track = tracks[4],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[5],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[6],
						  Genre = genres[3]
					 },
					 new TrackGenre {
						  Track = tracks[7],
						  Genre = genres[0]
					 },
					 new TrackGenre {
						  Track = tracks[8],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[9],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[10],
						  Genre = genres[1]
					 },
					 new TrackGenre {
						  Track = tracks[11],
						  Genre = genres[5]
					 },
					 new TrackGenre {
						  Track = tracks[12],
						  Genre = genres[6]
					 }
			};

			var albumTrack = new AlbumTrack[]
			{
					 new AlbumTrack {
						  Album = albums[0],
						  Track = tracks[0]
					 },
					 new AlbumTrack {
						  Album = albums[6],
						  Track = tracks[1]
					 },
					 new AlbumTrack {
						  Album = albums[1],
						  Track = tracks[2]
					 },
					 new AlbumTrack {
						  Album = albums[11],
						  Track = tracks[3]
					 },
					 new AlbumTrack {
						  Album = albums[12],
						  Track = tracks[4]
					 },
					 new AlbumTrack {
						  Album = albums[9],
						  Track = tracks[5]
					 },
					 new AlbumTrack {
						  Album = albums[8],
						  Track = tracks[6]
					 },
					 new AlbumTrack {
						  Album = albums[4],
						  Track = tracks[7]
					 },
					 new AlbumTrack {
						  Album = albums[3],
						  Track = tracks[8]
					 },
					 new AlbumTrack {
						  Album = albums[13],
						  Track = tracks[9]
					 },
					 new AlbumTrack {
						  Album = albums[5],
						  Track = tracks[10]
					 },
					 new AlbumTrack {
						  Album = albums[10],
						  Track = tracks[11]
					 },
					 new AlbumTrack {
						  Album = albums[12],
						  Track = tracks[12]
					 }
			};

			var userLikedTrack = new UserLikedTrack[]
			{
					 new UserLikedTrack {
						  User = users[0],
						  Track = tracks[0]
					 },
					 new UserLikedTrack {
						  User = users[1],
						  Track = tracks[2]
					 },
					 new UserLikedTrack {
						  User = users[1],
						  Track = tracks[12]
					 },
					 new UserLikedTrack {
						  User = users[1],
						  Track = tracks[4]
					 },
					 new UserLikedTrack {
						  User = users[1],
						  Track = tracks[1]
					 },
					 new UserLikedTrack {
						  User = users[2],
						  Track = tracks[4]
					 },
					 new UserLikedTrack {
						  User = users[2],
						  Track = tracks[5]
					 },
					 new UserLikedTrack {
						  User = users[3],
						  Track = tracks[11]
					 },
					 new UserLikedTrack {
						  User = users[4],
						  Track = tracks[7]
					 },
					 new UserLikedTrack {
						  User = users[4],
						  Track = tracks[8]
					 },
					 new UserLikedTrack {
						  User = users[4],
						  Track = tracks[9]
					 },
					 new UserLikedTrack {
						  User = users[5],
						  Track = tracks[3]
					 },
					 new UserLikedTrack {
						  User = users[5],
						  Track = tracks[0]
					 },
					 new UserLikedTrack {
						  User = users[6],
						  Track = tracks[10]
					 }
			};

			var trackAuthor = new TrackAuthor[]
			{
					 new TrackAuthor {
						  Author = authors[0],
						  Track = tracks[0]
					 },
					 new TrackAuthor {
						  Author = authors[11],
						  Track = tracks[1]
					 },
					 new TrackAuthor {
						  Author = authors[5],
						  Track = tracks[2]
					 },
					 new TrackAuthor {
						  Author = authors[7],
						  Track = tracks[3]
					 },
					 new TrackAuthor {
						  Author = authors[3],
						  Track = tracks[4]
					 },
					 new TrackAuthor {
						  Author = authors[4],
						  Track = tracks[5]
					 },
					 new TrackAuthor {
						  Author = authors[6],
						  Track = tracks[6]
					 },
					 new TrackAuthor {
						  Author = authors[8],
						  Track = tracks[7]
					 },
					 new TrackAuthor {
						  Author = authors[1],
						  Track = tracks[8]
					 },
					 new TrackAuthor {
						  Author = authors[14],
						  Track = tracks[9]
					 },
					 new TrackAuthor {
						  Author = authors[2],
						  Track = tracks[10]
					 },
					 new TrackAuthor {
						  Author = authors[10],
						  Track = tracks[11]
					 },
					 new TrackAuthor {
						  Author = authors[3],
						  Track = tracks[12]
					 }
			};

			var playlistTrack = new PlaylistTrack[]
			{
					 new PlaylistTrack{
						  Playlist = playlists[0],
						  Track = tracks[0]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[0],
						  Track = tracks[1]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[0],
						  Track = tracks[2]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[0],
						  Track = tracks[3]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[1],
						  Track = tracks[4]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[2],
						  Track = tracks[5]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[1],
						  Track = tracks[6]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[2],
						  Track = tracks[8]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[2],
						  Track = tracks[9]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[2],
						  Track = tracks[10]
					 },
					 new PlaylistTrack{
						  Playlist = playlists[2],
						  Track = tracks[11]
					 },
			};

			var albumAuthor = new AlbumAuthor[]
			{
					 new AlbumAuthor {
						  Author = authors [0],
						  Album = albums [0]
					 },
					 new AlbumAuthor {
						  Author = authors [1],
						  Album = albums [3]
					 },
					 new AlbumAuthor {
						  Author = authors [2],
						  Album = albums [5]
					 },
					 new AlbumAuthor {
						  Author = authors [3],
						  Album = albums [12]
					 },
					 new AlbumAuthor {
						  Author = authors [4],
						  Album = albums [9]
					 },
					 new AlbumAuthor {
						  Author = authors [5],
						  Album = albums [1]
					 },
					 new AlbumAuthor {
						  Author = authors [6],
						  Album = albums [8]
					 },
					 new AlbumAuthor {
						  Author = authors [7],
						  Album = albums [11]
					 },
					 new AlbumAuthor {
						  Author = authors [8],
						  Album = albums [4]
					 },
					 new AlbumAuthor {
						  Author = authors [9],
						  Album = albums [10]
					 },
					 new AlbumAuthor {
						  Author = authors [11],
						  Album = albums [6]
					 },
					 new AlbumAuthor {
						  Author = authors [12],
						  Album = albums [7]
					 },
					 new AlbumAuthor {
						  Author = authors [13],
						  Album = albums [2]
					 },
					 new AlbumAuthor {
						  Author = authors [14],
						  Album = albums [13]
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
				foreach (var err in result.Errors)
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
			{ // Контекст
			  ////! ОБЛОЖКИ АЛЬБОМОВ
				// Мизантропия
				string pathNorth = Path.Combine(Environment.CurrentDirectory, "Author\\11\\Albums\\Мизантропия\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 1, File.ReadAllBytes(pathNorth), "img/jpeg");

				// Babies
				string pathBabies = Path.Combine(Environment.CurrentDirectory, "Author\\Justin_Bieber\\Albums\\Babies\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 14, File.ReadAllBytes(pathBabies), "img/jpeg");

				// Beibs_In_The_Trap
				string pathBeibs = Path.Combine(Environment.CurrentDirectory, "Author\\Travis_Scott\\Albums\\Beibs_In_The_Trap\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 13, File.ReadAllBytes(pathBeibs), "img/jpeg");

				// Daft_Punk
				string pathPunk = Path.Combine(Environment.CurrentDirectory, "Author\\Daft_Punk\\Albums\\Homework\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 12, File.ReadAllBytes(pathPunk), "img/jpeg");

				// nectar
				string nectar = Path.Combine(Environment.CurrentDirectory, "Author\\Joji\\Joji.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 11, File.ReadAllBytes(nectar), "img/jpeg");

				// gorillaz
				string gorillaz = Path.Combine(Environment.CurrentDirectory, "Author\\Gorillaz\\Albums\\Demon_Days\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 10, File.ReadAllBytes(gorillaz), "img/jpeg");

				// Kanye_West
				string Kanye_West = Path.Combine(Environment.CurrentDirectory, "Author\\Kanye_West\\Albums\\Yeezus\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 9, File.ReadAllBytes(Kanye_West), "img/jpeg");

				// Phara
				string phara = Path.Combine(Environment.CurrentDirectory, "Author\\Pharaoh\\Albums\\PHLORA\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 8, File.ReadAllBytes(phara), "img/jpeg");

				// Morgenshtern
				string morgenshtern = Path.Combine(Environment.CurrentDirectory, "Author\\Morgenstern\\Albums\\Легендарная_пыль\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 7, File.ReadAllBytes(morgenshtern), "img/jpeg");

				// haski
				string haski = Path.Combine(Environment.CurrentDirectory, "Author\\Хаски\\Albums\\Любимые_песни_(воображаемых)_людей\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 6, File.ReadAllBytes(haski), "img/jpeg");

				// kizaru
				string kizaru = Path.Combine(Environment.CurrentDirectory, "Author\\Kizaru\\Albums\\Mas_Fuerte\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 5, File.ReadAllBytes(kizaru), "img/jpeg");

				// obladaet
				string obladaet = Path.Combine(Environment.CurrentDirectory, "Author\\Obladaet\\Albums\\DOUBLE_TAP\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 4, File.ReadAllBytes(obladaet), "img/jpeg");

				// Asap_Rocky
				string Asap_Rocky = Path.Combine(Environment.CurrentDirectory, "Author\\Asap_Rocky\\Albums\\Cozy_Tapes\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 3, File.ReadAllBytes(Asap_Rocky), "img/jpeg");

				// Drake
				string drake = Path.Combine(Environment.CurrentDirectory, "Author\\Drake\\Albums\\Scorpion\\Cover.jpg");
				fb.StoreFile(FileStorageFileType.AlbumCover, 2, File.ReadAllBytes(drake), "img/jpeg");

			}


			{
				////! АВАТАРКИ АВТОРОВ
				string pathNorthAva = Path.Combine(Environment.CurrentDirectory, "Author\\11\\11.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 1, File.ReadAllBytes(pathNorthAva), "img/jpeg");

				// Babies
				string pathBabiesAva = Path.Combine(Environment.CurrentDirectory, "Author\\Justin_Bieber\\Justin_Bieber.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 14, File.ReadAllBytes(pathBabiesAva), "img/jpeg");

				// Beibs_In_The_Trap
				string pathBeibsAva = Path.Combine(Environment.CurrentDirectory, "Author\\Travis_Scott\\Travis_Scott.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 13, File.ReadAllBytes(pathBeibsAva), "img/jpeg");

				// Daft_Punk
				string pathPunkAva = Path.Combine(Environment.CurrentDirectory, "Author\\Daft_Punk\\Daft_Punk.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 12, File.ReadAllBytes(pathPunkAva), "img/jpeg");

				// nectar
				string nectarAva = Path.Combine(Environment.CurrentDirectory, "Author\\Joji\\Joji.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 11, File.ReadAllBytes(nectarAva), "img/jpeg");

				// gorillaz
				string gorillazAva = Path.Combine(Environment.CurrentDirectory, "Author\\Gorillaz\\Gorillaz.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 10, File.ReadAllBytes(gorillazAva), "img/jpeg");

				// Kanye_West
				string Kanye_WestAva = Path.Combine(Environment.CurrentDirectory, "Author\\Kanye_West\\Kanye_West.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 9, File.ReadAllBytes(Kanye_WestAva), "img/jpeg");

				// Phara
				string pharaAva = Path.Combine(Environment.CurrentDirectory, "Author\\Pharaoh\\Pharaoh.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 8, File.ReadAllBytes(pharaAva), "img/jpeg");

				// Morgenshtern
				string morgenshternAva = Path.Combine(Environment.CurrentDirectory, "Author\\Morgenstern\\Morgenstern.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 7, File.ReadAllBytes(morgenshternAva), "img/jpeg");

				// haski
				string haskiAva = Path.Combine(Environment.CurrentDirectory, "Author\\Хаски\\Хаски.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 6, File.ReadAllBytes(haskiAva), "img/jpeg");

				// kizaru
				string kizaruAva = Path.Combine(Environment.CurrentDirectory, "Author\\Kizaru\\Kizaru.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 5, File.ReadAllBytes(kizaruAva), "img/jpeg");

				// obladaet
				string obladaetAva = Path.Combine(Environment.CurrentDirectory, "Author\\Obladaet\\Obladaet.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 4, File.ReadAllBytes(obladaetAva), "img/jpeg");

				// Asap_Rocky
				string Asap_RockyAva = Path.Combine(Environment.CurrentDirectory, "Author\\Asap_Rocky\\Asap_Rocky.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 3, File.ReadAllBytes(Asap_RockyAva), "img/jpeg");

				// Drake
				string drakeAva = Path.Combine(Environment.CurrentDirectory, "Author\\Drake\\Drake.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 2, File.ReadAllBytes(drakeAva), "img/jpeg");

				//? Те, у кого нет альбомов
				
				//Saluki
				string salukiAva = Path.Combine(Environment.CurrentDirectory, "Author\\Saluki\\Saluki.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 15, File.ReadAllBytes(salukiAva), "img/jpeg");

				// Schoolboy Q
				string schoolboyAva = Path.Combine(Environment.CurrentDirectory, "Author\\Schoolboy_Q\\Schoolboy_Q.jpg");
				fb.StoreFile(FileStorageFileType.AuthorAvatar, 16, File.ReadAllBytes(schoolboyAva), "img/jpeg");

			}

			{
				////! ТРЕКИ АВТОРОВ
				// Мизантропия
				string pathNorth = Path.Combine(Environment.CurrentDirectory, "Author\\11\\Albums\\Мизантропия\\СЕВЕРНЫЙ ФЛОТ - Поднимая знамя.mp3");
				fb.StoreFile(FileStorageFileType.Track, 13, File.ReadAllBytes(pathNorth), "audio/mpeg");

				// Babies
				string pathBabies = Path.Combine(Environment.CurrentDirectory, "Author\\Justin_Bieber\\Albums\\Babies\\Justin Bieber feat. Ludacris - Baby.mp3");
				fb.StoreFile(FileStorageFileType.Track, 4, File.ReadAllBytes(pathBabies), "audio/mpeg");

				// Beibs_In_The_Trap
				string pathBeibs1 = Path.Combine(Environment.CurrentDirectory, "Author\\Travis_Scott\\Albums\\Beibs_In_The_Trap\\Travis Scott - sdp interlude.mp3");
				string pathBeibs2 = Path.Combine(Environment.CurrentDirectory, "Author\\Travis_Scott\\Albums\\Beibs_In_The_Trap\\Travis Scott - goosebumps (ft. kendrick lamar).mp3");
				fb.StoreFile(FileStorageFileType.Track, 1, File.ReadAllBytes(pathBeibs1), "audio/mpeg");
				fb.StoreFile(FileStorageFileType.Track, 9, File.ReadAllBytes(pathBeibs2), "audio/mpeg");

				// Daft_Punk
				string pathPunk = Path.Combine(Environment.CurrentDirectory, "Author\\Daft_Punk\\Albums\\Homework\\Daft Punk - Around the World.mp3");
				fb.StoreFile(FileStorageFileType.Track, 10, File.ReadAllBytes(pathPunk), "audio/mpeg");

				// nectar
				string nectar = Path.Combine(Environment.CurrentDirectory, "Author\\Joji\\Albums\\Joji - NITROUS.mp3");
				fb.StoreFile(FileStorageFileType.Track, 2, File.ReadAllBytes(nectar), "audio/mpeg");

				// gorillaz
				string gorillaz = Path.Combine(Environment.CurrentDirectory, "Author\\Gorillaz\\Albums\\Demon_Days\\Gorillaz - Feel Good Inc..mp3");
				fb.StoreFile(FileStorageFileType.Track, 8, File.ReadAllBytes(gorillaz), "audio/mpeg");

				// Kanye_West
				string Kanye_West = Path.Combine(Environment.CurrentDirectory, "Author\\Kanye_West\\Albums\\Yeezus\\Kanye West - Hold My Liqour.mp3");
				fb.StoreFile(FileStorageFileType.Track, 7, File.ReadAllBytes(Kanye_West), "audio/mpeg");

				// Phara [НЕТ ТРЕКА]
				// string phara = Path.Combine(Environment.CurrentDirectory, "Author\\Pharaoh\\Albums\\PHLORA\\track.mp3");
				// fb.StoreFile(FileStorageFileType.Track, 8, File.ReadAllBytes(phara), "audio/mpeg");

				// Morgenshtern
				string morgenshtern = Path.Combine(Environment.CurrentDirectory, "Author\\Morgenstern\\Albums\\Легендарная_пыль\\MORGENSHTERN Элджей - Cadillac.mp3");
				fb.StoreFile(FileStorageFileType.Track, 12, File.ReadAllBytes(morgenshtern), "audio/mpeg");

				// haski
				string haski = Path.Combine(Environment.CurrentDirectory, "Author\\Хаски\\Albums\\Любимые_песни_(воображаемых)_людей\\Хаски - Панелька [Рифмы и Панчи].mp3");
				fb.StoreFile(FileStorageFileType.Track, 3, File.ReadAllBytes(haski), "audio/mpeg");

				// kizaru
				string kizaru = Path.Combine(Environment.CurrentDirectory, "Author\\Kizaru\\Albums\\Mas_Fuerte\\KIZARU - Оу Щит.mp3");
				fb.StoreFile(FileStorageFileType.Track, 6, File.ReadAllBytes(kizaru), "audio/mpeg");

				// obladaet
				string obladaet = Path.Combine(Environment.CurrentDirectory, "Author\\Obladaet\\Albums\\DOUBLE_TAP\\OBLADAET - DOUBLE TAP.mp3");
				fb.StoreFile(FileStorageFileType.Track, 5, File.ReadAllBytes(obladaet), "audio/mpeg");

				// Asap_Rocky [НЕТ ТРЕКА]
				// string Asap_Rocky = Path.Combine(Environment.CurrentDirectory, "Author\\Asap_Rocky\\Albums\\Cozy_Tapes\\Cover.mp3");
				// fb.StoreFile(FileStorageFileType.Track, 3, File.ReadAllBytes(Asap_Rocky), "audio/mpeg");

				// Drake
				string drake = Path.Combine(Environment.CurrentDirectory, "Author\\Drake\\Albums\\Scorpion\\Drake - Nonstop.mp3");
				fb.StoreFile(FileStorageFileType.Track, 11, File.ReadAllBytes(drake), "audio/mpeg");
			}

			////! АВАТАРКИ ПОЛЬЗОВАТЕЛЕЙ

			//TODO

			// 1) Северный флот не 1-й id
			// 2) Почмотреть как заполняются все альбомы + треки + User
			// 3) Синхронизировать id сущностей и файлов..


		}
	}
}
