using System.Collections.Generic;

namespace Spotify.Domain.Entities
{
    /// <value>
    /// Класс семейтсва тегов.
    /// Используется для улчушения подборок треков.
    /// </value>
    public class TagFamily
    {
        public int TagFamilyId { get; set; }

        public string Name { get; set; }

        public List<Tag> Tags { get; }
    }
}
