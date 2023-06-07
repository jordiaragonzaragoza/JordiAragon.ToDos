namespace JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record class GeocodeResponse
    {
        [JsonPropertyName("plus_code")]
        public PlusCodeResponse PlusCode { get; init; }

        [JsonPropertyName("results")]
        public IEnumerable<GeocodeResultResponse> Results { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }
    }
}