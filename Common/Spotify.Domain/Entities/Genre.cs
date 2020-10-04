using Spotify.Domain.Entities.Base;

namespace Spotify.Domain.Entities
{
    public class Genre : NamedEntity
    {
        public string Description { get; set; }

        public long Auditions { get; set; }
    }
}