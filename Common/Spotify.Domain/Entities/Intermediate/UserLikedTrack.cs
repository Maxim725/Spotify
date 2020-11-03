using Spotify.Domain.Entities.Identity;

namespace Spotify.Domain.Entities.Intermediate
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Entities.Track"/> и <see cref="Identity.User"/>
    /// </summary>
    public class UserLikedTrack
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }
    }
}
