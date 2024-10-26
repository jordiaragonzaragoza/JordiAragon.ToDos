namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record class AddressComponentResponse
    {
        [JsonPropertyName("long_name")]
        public string LongName { get; init; }

        [JsonPropertyName("short_name")]
        public string ShortName { get; init; }

        [JsonPropertyName("types")]
        public IEnumerable<string> Types { get; init; }
    }
}