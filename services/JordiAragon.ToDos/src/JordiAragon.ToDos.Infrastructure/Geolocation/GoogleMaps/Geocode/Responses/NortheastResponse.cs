namespace JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Text.Json.Serialization;

    public record class NortheastResponse
    {
        [JsonPropertyName("lat")]
        public double Lat { get; init; }

        [JsonPropertyName("lng")]
        public double Lng { get; init; }
    }
}