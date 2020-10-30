using Spotify.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.Entities
{
	public class UserSubscription
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int SubscriptionId { get; set; }

		public User Subscription { get; set; }
	}
}
