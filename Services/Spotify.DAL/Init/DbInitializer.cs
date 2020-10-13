using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Init()
        {
            var db = _db.Database;

            try
            {
                _logger.LogInformation("Проведение миграций БД");
                db.Migrate();

                _logger.LogInformation("Добавление обощённых тегов");
                InitializeTagFamilies();

                _logger.LogInformation("Добавление тегов");
                InitializeTags();

                _logger.LogInformation("Добавление жанров");
                InitializeGenre();

                _logger.LogInformation("Добавление пользователей");
                InitializeUsers();

                _logger.LogInformation("Добавление авторов");
                InitializeAuthors();


                _logger.LogInformation("Заполнение БД треками");
                InitializeTracks();
            }
            catch(Exception ex)
            {
                _logger.LogCritical(new EventId(-1), ex, "Ошибка инициализации БД");
                
                throw;
            }
        }
        private void InitializeTagFamilies()
        {

        }
        private void InitializeTags()
        {

        }
        private void InitializeGenre()
        {

        }

        private void InitializeUsers()
        {
            

        }
        private void InitializeTracks()
        {

        }


        private void InitializeAuthors()
        {

        }


    }
}
