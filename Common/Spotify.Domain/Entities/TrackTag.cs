namespace Spotify.Domain.Entities
{
    /// <summary>
    /// Класс тега трека.
    /// Теги используются для указания субъективной информации о треке.
    /// Например, "для сна", "осень".
    /// </summary>
    public class TrackTag
    {
        public int TrackId { get; set; }

        public Track Track { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
