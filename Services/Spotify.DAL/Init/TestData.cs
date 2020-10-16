using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Spotify.DAL.Init
{
    public static class TestData
    {
        public static TagFamily[] TagFamilies { get; } = new[]
        {
            new TagFamily { Id = 1, Name = "Жизнерадостная музыка"},
            new TagFamily { Id = 2, Name = "Быстрая музыка"},
            new TagFamily { Id = 3, Name = "Медленная музыка"},
            new TagFamily { Id = 4, Name = "Смешанная музыка"},
        };

        public static TrackTag[] Tags { get; } = new[]
        {
            new TrackTag { Id = 1, Name = "Весёлая", TagFamily = new[] { TagFamilies[0], TagFamilies[1] } },
            new TrackTag { Id = 2, Name = "Грустная", TagFamily = new[] { TagFamilies[2] } },
            new TrackTag { Id = 3, Name = "Рок", TagFamily = new[] { TagFamilies[3] } }
        };

        public static Genre[] Genres { get; } = new[]
        {
            new Genre { Id = 1, Name = "Рок", Description = "Рок музыка (англ. Rock music)", Plays = 0 },
            new Genre { Id = 2, Name = "Рэп", Description = "Рэп (англ. rap, rapping)", Plays = 0 },
            new Genre { Id = 3, Name = "Альтернативная музыка", Description = "Жанр рок-музыки, сформировавшийся из музыкального андеграунда)", Plays = 0 },
            new Genre { Id = 4, Name = "Фонк", Description = "Поджанр хип-хопа и трэпа, вдохновлённый Мемфис-рэпом 1990-х годов.", Plays = 0 },
            new Genre { Id = 5, Name = "Хип-хоп", Description = "Музыкальный жанр, сочетающий рэп с электронным битом, сэмплами и прочим музыкальным сопровождением в исполнении ди-джея.", Plays = 0 }
        };

        public static Author[] Authors { get; } = new[]
        {
            new Author { Id = 1, Name = "Obladaet", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[0] }  , Image = "Spotify/Authors/1.mp3", Plays = 0 } ,
            new Author { Id = 2, Name = "Хаски", Confirmed = true, Biography = "Закончил МГУ, а стал гопником. Современный Есенин.", CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[1] }, Image = "Spotify/Authors/фыв", Plays = 0 },
            new Author { Id = 3, Name = "Travis Scott", Confirmed = true , Biography = "The best rapper in the world. Became from nothing to something. Astro everywhere...", CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[2] }, Image = "Spotify/Authors/фыв", Plays = 0 },
            new Author { Id = 4, Name = "Gorillaz", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[3] }, Image = "Spotify/Authors/jpg", Plays = 0 },
            new Author { Id = 5, Name = "Drake", Confirmed = false, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[4] }, Image = "Spotify/Authors/sdjpg", Plays = 0 },
            new Author { Id = 6, Name = "Kanye West", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[5] }, Image = "Spotify/Authors/asdjpg", Plays = 0 },
            new Author { Id = 7, Name = "Daft Punk", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[6] }, Image = "Spotify/Authors/asdjpg", Plays = 0 },
            new Author { Id = 8, Name = "Kizaru", Confirmed = false, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[7] }, Image = "Spotify/Authors/asd.jpg", Plays = 0 },
            new Author { Id = 9, Name = "Joji", Confirmed = false, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[8] }, Image = "Spotify/Authors/asd.jpg", Plays = 0 },
            new Author { Id = 10, Name = "Saluki", Confirmed = false, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[9] }, Image = "Spotify/Authors/wsx.jpg", Plays = 0 },
            new Author { Id = 11, Name = "Morgenstern", Confirmed = false, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[10] }, Image = "Spotify/Authors/ert.jpg", Plays = 0 },
            new Author { Id = 12, Name = "Pharaoh", Confirmed = false, CreationDate = new DateTime(2013, 02, 01), Albums = new[] { AuthorAlbums[11] }, Image = "Spotify/Authors/ikl.jpg", Plays = 0 },
            new Author { Id = 13, Name = "Asap Rocky", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Image = "Spotify/Authors/qaz.jpg", Plays = 0 },
            new Author { Id = 14, Name = "Justin Bieber", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Image = "Spotify/Authors/edc.jpg", Plays = 0 },
            new Author { Id = 15, Name = "Schoolboy Q", Confirmed = true, CreationDate = new DateTime(2013, 02, 01), Image = "Spotify/Authors/tgb.jpg", Plays = 0 }
        };

        public static Track[] Tracks { get; } = new[]
        {
            new Track { Id = 1, Name = "Cadillac", SoundPath = "Spotify/tracks/Cadillac1.mp3", Duration = 183, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[5], Image = "Spotify/albumsImgs/asd.jpg", Authors = new[] {Authors[10]} , Tags = new[] {Tags[0]}, Genres = new[] {Genres[4]} },
            new Track { Id = 2, Name = "Nonstop", SoundPath = "Spotify/tracks/Nonstop2.mp3", Duration = 182, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[0], Image = "Spotify/albumsImgs/Album..jpg", Authors = new[] {Authors[4]} , Tags = new[] {Tags[1]}, Genres = new[] {Genres[4]} },
            new Track { Id = 3, Name = "Around the world", SoundPath = "Spotify/tracks/Aroundtheworld3.mp3", Duration = 162, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[10], Image = "Spotify/albumsImgs/Album.jpg", Authors = new[] {Authors[6]} , Tags = new[] {Tags[1]}, Genres = new[] {Genres[4]} },
            new Track { Id = 4, Name = "Goosebumps", SoundPath = "Spotify/tracks/Goosebumps4.mp3", Duration = 199, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[11], Image = "Spotify/albumsImgs/Album.jpg", Authors = new[] {Authors[2]} , Tags = new[] {Tags[1],Tags[2]}, Genres = new[] {Genres[4]} },
            new Track { Id = 5, Name = "Fell Good Inc.", SoundPath = "Spotify/tracks/FellGoodInc.5.mp3", Duration = 155, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[8], Image = "Spotify/albumsImgs/Album.jpg", Authors = new[] {Authors[3]} , Tags = new[] {Tags[2]}, Genres = new[] {Genres[4]} },
            new Track { Id = 6, Name = "Hold My Liqour", SoundPath = "Spotify/tracks/HoldMyLiqour6.mp3", Duration = 144, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[7], Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[5]} , Tags = new[] {Tags[0]}, Genres = new[] {Genres[4]} },
            new Track { Id = 7, Name = "Оу щит", SoundPath = "Spotify/tracks/Оущит7.mp3", Duration = 142, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[3], Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[7]} , Tags = new[] {Tags[1]}, Genres = new[] {Genres[4]} },
            new Track { Id = 8, Name = "Double Tap", SoundPath = "Spotify/tracks/DoubleTap8.mp3", Duration = 140, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[2], Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[1]} , Tags = new[] {Tags[2]}, Genres = new[] {Genres[4]} },
            new Track { Id = 9, Name = "Baby", SoundPath = "Spotify/tracks/Baby9.mp3", Duration = 221, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[14]} , Tags = new[] {Tags[0]}, Genres = new[] {Genres[4]} },
            new Track { Id = 10, Name = "Панелька", SoundPath = "Spotify/tracks/Панелька10.mp3", Duration = 130, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[4], Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[1]} , Tags = new[] {Tags[1]}, Genres = new[] {Genres[4]} },
            new Track { Id = 11, Name = "NITROUS", SoundPath = "Spotify/tracks/NITROUS11.mp3", Duration = 194, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[9], Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[8]} , Tags = new[] {Tags[2]}, Genres = new[] {Genres[4]} },
            new Track { Id = 12, Name = "sdp", SoundPath = "Spotify/tracks/sdp12.mp3", Duration = 191, Plays = 0, UploadDate = new DateTime(2013, 02, 01), Album = Albums[11], Image = "Spotify/albumsImgs/ Album.jpg", Authors = new[] {Authors[2]} , Tags = new[] {Tags[1]}, Genres = new[] {Genres[4]} }
        };

        public static Album[] Albums { get; } = new[]
        {
            new Album { Id = 1, Name = "Scorpion", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[1] }, Plays = 0, Duration = 455, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[0] }, Cover = "Spotify/albumsImgs/Scorpion1.jpeg" },
            new Album { Id = 2, Name = "Cozy Tapes", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[2] }, Plays = 0, Duration = 206, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[1] }, Cover = "Spotify/albumsImgs/CozyTapes2.jpeg" },
            new Album { Id = 3, Name = "DOUBLE TAP", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[3] }, Plays = 0, Duration = 203, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[2] }, Cover = "Spotify/albumsImgs/DOUBLETAP3.jpeg" },
            new Album { Id = 4, Name = "Mas Fuerte", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[4] }, Plays = 0, Duration = 147, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[3] }, Cover = "Spotify/albumsImgs/MasFuerte4.jpeg" },
            new Album { Id = 5, Name = "Любимые песни", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[5] }, Plays = 0, Duration = 424, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[4] }, Cover = "Spotify/albumsImgs/Любимыепесни(воображаемых)людей5.jpeg" },
            new Album { Id = 6, Name = "Легендарная пыль", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[6] }, Plays = 0, Duration = 225, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[5] }, Cover = "Spotify/albumsImgs/Легендарнаяпыль6.jpeg" },
            new Album { Id = 7, Name = "PHLORA", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[7] }, Plays = 0, Duration = 326, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[6] }, Cover = "Spotify/albumsImgs/PHLORA7.jpeg" },
            new Album { Id = 8, Name = "Yeezus", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[8] }, Plays = 0, Duration = 390, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[7] }, Cover = "Spotify/albumsImgs/Yeezus8.jpeg" },
            new Album { Id = 9, Name = "Demon Days", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[9] }, Plays = 0, Duration = 411, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[8] }, Cover = "Spotify/albumsImgs/DemonDays9.jpeg" },
            new Album { Id = 10, Name = "Nectar", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[10] }, Plays = 0, Duration = 238, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[9] }, Cover = "Spotify/albumsImgs/Nectar10.jpeg" },
            new Album { Id = 11, Name = "Homework", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[0] }, Plays = 0, Duration = 158, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[10] }, Cover = "Spotify/albumsImgs/Homework11.jpeg" },
            new Album { Id = 12, Name = "Beibs In The Trap", Description = "", CreationDate = new DateTime(2013, 02, 01), Tracks = new[] {Tracks[11] }, Plays = 0, Duration = 158, PublicationDate = new DateTime(2015,02,01), Authors = new[] { AuthorAlbums[11] } , Cover = "Spotify/albumsImgs/BeibsInTheTrap12.jpeg" }

        };

        public static User[] Users { get; } = new[]
        {
            new User {Id = 1, UserName = "12dot", CreationDate = new DateTime(2020,05,04), Playlists = new[] { PlaylistUsers[0], PlaylistUsers[1] }, Avatar = "Spotify/User/Name.jpg"},
            new User {Id = 2, UserName = "David", CreationDate = new DateTime(2020,05,04), Playlists =  new[] { PlaylistUsers[2], PlaylistUsers[3] }, Avatar = "Spotify/User/Name.jpg"},//
            new User {Id = 3, UserName = "Nekit", CreationDate = new DateTime(2020,05,04), Playlists = new[] { PlaylistUsers[4], PlaylistUsers[5] }, Avatar = "Spotify/User/Name.jpg"},//
            new User {Id = 4, UserName = "Ilya", CreationDate = new DateTime(2020,05,04), Playlists = new[] { PlaylistUsers[6], PlaylistUsers[7] }, Avatar = "Spotify/User/Name.jpg"}, //
            new User {Id = 5, UserName = "Masha", CreationDate = new DateTime(2020,05,04), Playlists = new[] { PlaylistUsers[8], PlaylistUsers[9], PlaylistUsers[10] }, Avatar = "Spotify/User/Name.jpg"},
            new User {Id = 6, UserName = "Katya", CreationDate = new DateTime(2020,05,04), Avatar = "Spotify/User/Name.jpg"} //
        };

        public static Playlist[] Playlists { get; } = new[] {
            new Playlist { Id = 1 , Name = "qwert", Description = "LolCheckKek", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[2], Plays = 0, Duration = 601 },
            new Playlist { Id = 2 , Name = "fdsdslkfdsmm", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[5], Plays = 0, Duration = 573 },
            new Playlist { Id = 3 , Name = "qdjisofjsd", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[3], Plays = 0, Duration = 248 },
            new Playlist { Id = 4 , Name = "qfkgfhmlgf", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[5], Plays = 0, Duration = 474 },
            new Playlist { Id = 5 , Name = "qfdsfdsfds", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[1], Plays = 0, Duration = 739 },
            new Playlist { Id = 6 , Name = "zxcxzvxvxc", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[4], Plays = 0, Duration = 644 },
            new Playlist { Id = 7 , Name = "Game", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[2], Plays = 0, Duration = 560 },
            new Playlist { Id = 8 , Name = "PaylisterAh", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[4], Plays = 0, Duration = 594 },
            new Playlist { Id = 9 , Name = "kssdsdsa", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[3], Plays = 0, Duration = 742 },
            new Playlist { Id = 10 , Name = "mnnbjnjk", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[5], Plays = 0, Duration = 627 },
            new Playlist { Id = 11 , Name = "dsadsadasqqqwqew", CreationDate = new DateTime(2020, 04, 04), UpdateDate = new DateTime(2020, 04, 04), Tracks = Tracks, CreatedBy = Users[4], Plays = 0, Duration = 293 },
        };

        public static AuthorAlbum[] AuthorAlbums { get; } = new[]
        {
            new AuthorAlbum{ AlbumId = 1, AuthorId = 1 },
            new AuthorAlbum{ AlbumId = 2, AuthorId = 2 },
            new AuthorAlbum{ AlbumId = 3, AuthorId = 3 },
            new AuthorAlbum{ AlbumId = 4, AuthorId = 4 },
            new AuthorAlbum{ AlbumId = 5, AuthorId = 5 },
            new AuthorAlbum{ AlbumId = 6, AuthorId = 6 },
            new AuthorAlbum{ AlbumId = 7, AuthorId = 7 },
            new AuthorAlbum{ AlbumId = 8, AuthorId = 8 },
            new AuthorAlbum{ AlbumId = 9, AuthorId = 9 },
            new AuthorAlbum{ AlbumId = 10, AuthorId = 10 },
            new AuthorAlbum{ AlbumId = 11, AuthorId = 11 },
            new AuthorAlbum{ AlbumId = 12, AuthorId = 12 },

        };

        public static PlaylistUser[] PlaylistUsers { get; } = new[]
        {
            new PlaylistUser { PlaylistId = 1, UserId = 1 },
            new PlaylistUser { PlaylistId = 2, UserId = 1 },
            new PlaylistUser { PlaylistId = 3, UserId = 2 },
            new PlaylistUser { PlaylistId = 4, UserId = 2 },
            new PlaylistUser { PlaylistId = 5, UserId = 3 },
            new PlaylistUser { PlaylistId = 6, UserId = 3 },
            new PlaylistUser { PlaylistId = 7, UserId = 4 },
            new PlaylistUser { PlaylistId = 8, UserId = 4 },
            new PlaylistUser { PlaylistId = 9, UserId = 5 },
            new PlaylistUser { PlaylistId = 10, UserId = 5 },
            new PlaylistUser { PlaylistId = 11, UserId = 5 },
        };
        public static string[] Roles = new[]
        {
            "Admin", "User", "Moderator"
        };
    }
}
