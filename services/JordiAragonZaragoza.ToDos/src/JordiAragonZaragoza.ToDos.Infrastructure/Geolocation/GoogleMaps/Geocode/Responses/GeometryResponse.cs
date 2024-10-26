namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Text.Json.Serialization;

    public record class GeometryResponse
    {
        [JsonPropertyName("location")]
        public LocationResponse Location { get; init; }

        [JsonPropertyName("location_type")]
        public string LocationType { get; init; }

        [JsonPropertyName("viewport")]
        public ViewportResponse Viewport { get; init; }

        [JsonPropertyName("bounds")]
        public BoundsResponse Bounds { get; init; }
    }
}