using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
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
            new Author { Id = 1, Name = "Подзалупник", }
        };

        public static string[] Roles = new[]
        {
            "Admin", "User", "Moderator"
        };
    }
}
