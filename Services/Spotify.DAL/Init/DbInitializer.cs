using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.DAL.Init
{
    public class DbInitializer
    {
        private readonly SpotifyDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(SpotifyDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            ILogger<DbInitializer> logger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task Init()
        {
            var db = _db.Database;

            try
            {
                _logger.LogInformation("Проведение миграций БД");
                db.Migrate();

                _logger.LogInformation("Добавление обощённых тегов");
                await InitializeTagFamilies();

                _logger.LogInformation("Добавление тегов");
                await InitializeTags();

                _logger.LogInformation("Добавление жанров");
                await InitializeGenre();

                _logger.LogInformation("Добавление пользователей");
                await InitializeUsers();

                _logger.LogInformation("Добавление авторов");
                await InitializeAuthors();


                _logger.LogInformation("Заполнение БД треками");
                await InitializeTracks();

                _logger.LogInformation("Добавление плейлистов");
                await InitializePlaylists();

                _logger.LogInformation("Добавление альбомов");
                await InitializeAlbums();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(new EventId(-1), ex, "Ошибка инициализации БД");
                
                throw;
            }
        }
        // Можно сделать рефракторинг кода (создав универсальный обощённый метод, принимающий данные, и стору названия таблицы)!
        private async Task InitializeTagFamilies()
        {
            _logger.LogInformation("Проверка на пустоту таблицы TagFamilies");
            if (_db.TagFamilies.Any())
            {
                _logger.LogInformation("В таблица TagFamilies инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {

                _logger.LogInformation("Добавление данных в Кеш");
                await _db.TagFamilies.AddRangeAsync(TestData.TagFamilies);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы TagFamilies");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT TagFamilies ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы TagFamilies");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT TagFamilies OFF");

                db.CommitTransaction();
            }

        }
        private async Task InitializeTags()
        {
            _logger.LogInformation("Проверка на пустоту таблицы TrackTags");
            if (_db.TrackTags.Any())
            {
                _logger.LogInformation("Таблица TrackTags инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.TrackTags.AddRangeAsync(TestData.Tags);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы TrackTags");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT TrackTags ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы TrackTags");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT TrackTags OFF");

                db.CommitTransaction();
            }
        }
        private async Task InitializeGenre()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Genres");
            if (_db.Genres.Any())
            {
                _logger.LogInformation("Таблица Genres инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.Genres.AddRangeAsync(TestData.Genres);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы Genres");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Genres ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы Genres");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Genres OFF");

                db.CommitTransaction();
            }
        }
        private async Task InitializeTracks()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Tracks");
            if (_db.Tracks.Any())
            {
                _logger.LogInformation("Таблица Tracks инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.Tracks.AddRangeAsync(TestData.Tracks);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы Tracks");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Tracks ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы Tracks");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Tracks OFF");

                db.CommitTransaction();
            }
        }
        private async Task InitializeAuthors()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Authors");
            if (_db.Authors.Any())
            {
                _logger.LogInformation("Таблица Authors инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.Authors.AddRangeAsync(TestData.Authors);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы Authors");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Authors ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы Authors");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Authors OFF");

                db.CommitTransaction();
            }
        }
        private async Task InitializePlaylists()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Playlists");
            if (_db.Playlists.Any())
            {
                _logger.LogInformation("Таблица Playlists инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.Playlists.AddRangeAsync(TestData.Playlists);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы Playlists");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Playlists ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы Playlists");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Playlists OFF");

                db.CommitTransaction();
            }
        }
        private async Task InitializeAlbums()
        {
            _logger.LogInformation("Проверка на пустоту таблицы Albums");
            if (_db.Albums.Any())
            {
                _logger.LogInformation("Таблица Albums инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.Albums.AddRangeAsync(TestData.Albums);

                _logger.LogInformation("Отключение автоинкрементирования id у таблицы Albums");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Albums ON");

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                _logger.LogInformation("Включение автоинкрементирования id у таблицы Albums");
                db.ExecuteSqlRaw("SET IDENTITY_INSERT Albums OFF");

                db.CommitTransaction();
            }
        }
        private async Task InitializeIntermediateTables()
        {
            _logger.LogInformation("Проверка на пустоту таблицы AuthorAlbums");
            if (_db.AuthorAlbums.Any())
            {
                _logger.LogInformation("Таблица AuthorAlbums инициализирована");
                return;
            }

            var db = _db.Database;
            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.AuthorAlbums.AddRangeAsync(TestData.AuthorAlbums);

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                db.CommitTransaction();
            }

            _logger.LogInformation("Проверка на пустоту таблицы PlaylistUser");
            if (_db.PlaylistUsers.Any())
            {
                _logger.LogInformation("Таблица PlaylistUser инициализирована");
                return;
            }

            using (db.BeginTransaction())
            {
                _logger.LogInformation("Добавление данных в Кеш");
                await _db.PlaylistUsers.AddRangeAsync(TestData.PlaylistUsers);

                _logger.LogInformation("Сохранение кеша в БД");
                _db.SaveChanges();

                db.CommitTransaction();
            }
        }

        private async Task InitializeUsers()
        {
        }




    }
}
