using Spotify.Domain.Entities.Identity;

namespace Spotify.Domain.Entities.Intermediate
{
    /// <summary>
    /// Ассоциативная сущность для <see cref="Entities.Author"/> и <see cref="Identity.User"/>
    /// </summary>
    public class UserLikedAuthor
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
