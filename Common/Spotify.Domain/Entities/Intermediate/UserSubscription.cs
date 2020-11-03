using Spotify.Domain.Entities.Identity;

namespace Spotify.Domain.Entities.Intermediate
{
    public class UserSubscription
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int SubscriptionId { get; set; }

        public User Subscription { get; set; }
    }
}
