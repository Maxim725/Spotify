namespace Spotify.Domain.Entities
{
	public class Tag
	{
		public int TagId { get; set; }

		public string Name { get; set; }

		public int FamilyId { get; set; }

		public TagFamily Family { get; set; }
	}
}
