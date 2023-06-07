namespace JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record class GeocodeResultResponse
    {
        [JsonPropertyName("address_components")]
        public IEnumerable<AddressComponentResponse> AddressComponents { get; init; }

        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; init; }

        [JsonPropertyName("geometry")]
        public GeometryResponse Geometry { get; init; }

        [JsonPropertyName("place_id")]
        public string PlaceId { get; init; }

        [JsonPropertyName("plus_code")]
        public PlusCodeResponse PlusCode { get; init; }

        [JsonPropertyName("types")]
        public IEnumerable<string> Types { get; init; }
    }
}