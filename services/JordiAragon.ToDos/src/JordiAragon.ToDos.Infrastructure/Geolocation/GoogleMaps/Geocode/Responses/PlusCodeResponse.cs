namespace JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Text.Json.Serialization;

    public record class PlusCodeResponse
    {
        [JsonPropertyName("compound_code")]
        public string CompoundCode { get; init; }

        [JsonPropertyName("global_code")]
        public string GlobalCode { get; init; }
    }
}