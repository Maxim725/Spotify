using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Spotify.Domain.Entities;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.DAL.Init
{
    public class DbInitializer
    {
        private readonly SpotifyDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(SpotifyDbContext db, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager,
            ILogger<DbInitializer> logger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public void Init()
        {
            var db = _db.Database;

            TestData.BindData();

            try
            {
                using (db.BeginTransaction())
                {

                    _logger.LogInformation("Проведение миграций БД");
                    db.Migrate();

                    _logger.LogInformation("Добавление обощённых тегов");
                    InitializeTagFamilies();

                    _logger.LogInformation("Добавление тегов");
                    InitializeTags();

                    _logger.LogInformation("Добавление жанров");
                    InitializeGenre();
                    _db.SaveChanges();


                    
                    _logger.LogInformation("Добавление альбомов");
                    InitializeAlbums();

                    _logger.LogInformation("Добавление авторов");
                    InitializeAuthors();
                    _db.SaveChanges();

                    _logger.LogInformation("Заполнение БД треками");
                    InitializeTracks();
                    _db.SaveChanges();


                    _logger.LogInformation("Добавление пользователей");
                    InitializeUsers();
                    _db.SaveChanges();

                    _logger.LogInformation("Добавление плейлистов");
                    InitializePlaylists();

                    InitializeIntermediateTables();
                    _db.SaveChanges();
                    //_db.SaveChanges();



                    _db.SaveChanges();

                    db.CommitTransaction();
                }
            }
            catch(Exception ex)
            {
                _logger.LogCritical(new EventId(-1), ex, "Ошибка инициализации БД");
                
                 throw;
            }
        }
        // Можно сделать рефракторинг кода (создав универсальный обощённый метод, принимающий данные, и стору названия таблицы)!
        private void InitializeTagFamilies()
        {
            _logger.LogInformation("Проверка на пустоту таблицы TagFamilies");
            if (_db.TagFamilies.Any())
            {
                _logger.LogInformation("В таблица TagFamilies инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.TagFamilies.AddRange(TestData.TagFamilies);
        }
        private void InitializeTags()
        {
            _logger.LogInformation("Проверка на пустоту таблицы TrackTags");
            if (_db.TrackTags.Any())
            {
                _logger.LogInformation("Таблица TrackTags инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.TrackTags.AddRange(TestData.Tags);
        }
        private void InitializeGenre()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Genres");
            if (_db.Genres.Any())
            {
                _logger.LogInformation("Таблица Genres инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.Genres.AddRange(TestData.Genres);
        }
        private void InitializeTracks()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Tracks");
            if (_db.Tracks.Any())
            {
                _logger.LogInformation("Таблица Tracks инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.Tracks.AddRange(TestData.Tracks);
        }
        private void InitializeAuthors()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Authors");
            if (_db.Authors.Any())
            {
                _logger.LogInformation("Таблица Authors инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.Authors.AddRange(TestData.Authors);
        }
        private void InitializePlaylists()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Playlists");
            if (_db.Playlists.Any())
            {
                _logger.LogInformation("Таблица Playlists инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.Playlists.AddRange(TestData.Playlists);
        }
        private void InitializeAlbums()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Albums");
            if (_db.Albums.Any())
            {
                _logger.LogInformation("Таблица Albums инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.Albums.AddRange(TestData.Albums);
        }
        private void InitializeIntermediateTables()
        {
            _logger.LogInformation("Проверка на пустоту таблицы AuthorAlbums");
            if (_db.AuthorAlbums.Any())
            {
                _logger.LogInformation("Таблица AuthorAlbums инициализирована");
                return;
            }


            _logger.LogInformation("Добавление данных в Кеш");
            _db.AuthorAlbums.AddRange(TestData.AuthorAlbums);


            _logger.LogInformation("Проверка на пустоту таблицы PlaylistUser");
            if (_db.PlaylistUsers.Any())
            {
                _logger.LogInformation("Таблица PlaylistUser инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.PlaylistUsers.AddRange(TestData.PlaylistUsers);

            if (_db.PlaylistTrack.Any())
            {
                _logger.LogInformation("Таблица PlaylistTracks инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.PlaylistTrack.AddRange(TestData.PlaylistTracks);


            if (_db.TagTrackTag.Any())
            {
                _logger.LogInformation("Таблица PlaylisTagTrackstTracks инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.TagTrackTag.AddRange(TestData.TagTracks);
        }
        private void InitializeUsers()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Users");
            if (_db.Users.Any())
            {
                _logger.LogInformation("Таблица Users инициализирована");
                return;
            }

            _logger.LogInformation("Добавление данных в Кеш");
            _db.Users.AddRange(TestData.Users);

            _logger.LogInformation("Сохранение кеша в БД");
        }




    }
}
