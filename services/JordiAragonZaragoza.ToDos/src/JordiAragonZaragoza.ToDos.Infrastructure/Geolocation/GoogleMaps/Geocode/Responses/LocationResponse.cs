namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Text.Json.Serialization;

    public record class LocationResponse
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; init; }

        [JsonPropertyName("lng")]
        public double Longitude { get; init; }
    }
}