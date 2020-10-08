using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    /// <summary> Класс, описывающий жанр </summary>
    public class Genre : NamedEntity
    {
        /// <summary> Описание жанра </summary>
        public string Description { get; set; }

        /// <summary> Прослушиваний у жанра (должна обновляться раз в месяц) </summary>
        public long Auditions { get; set; }
    }
}