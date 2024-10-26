namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Text.Json.Serialization;

    public record class BoundsResponse
    {
        [JsonPropertyName("northeast")]
        public NortheastResponse Northeast { get; init; }

        [JsonPropertyName("southwest")]
        public SouthwestResponse Southwest { get; init; }
    }
}