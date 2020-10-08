using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    /// <summary> Промежуточная модель данных </summary>
    public class AuthorAlbum : IdEntity
    {
        /// <summary> Альбом </summary>
        public Album Album { get; set; }

        /// <summary> Автор альбома </summary>
        public Author Author { get; set; }

    }
}
