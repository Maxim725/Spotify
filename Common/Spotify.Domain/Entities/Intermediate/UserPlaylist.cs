using Spotify.Domain.Entities.Identity;

namespace Spotify.Domain.Entities.Intermediate
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Entities.Playlist"/> и <see cref="Identity.User"/>
    /// </summary>
    public class UserPlaylist
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int PlaylistId { get; set; }

        public Playlist Playlist { get; set; }
    }
}
