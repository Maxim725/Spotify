using Spotify.Domain.Entities.Identity;

namespace Spotify.Domain.Entities.Intermediate
{
    public class UserLikedAlbum
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
