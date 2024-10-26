namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps
{
    using System.Threading;
    using System.Threading.Tasks;
    using JordiAragon.SharedKernel.Contracts.DependencyInjection;
    using JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Requests;
    using JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses;
    using Refit;

    [Headers("Content-Type: application/json")]
    public interface IGoogleMapsWebApi : IIgnoreDependency
    {
        [Get("/maps/api/geocode/json")]
        Task<GeocodeResponse> GetGeocodeFromAddressAsync([Query] string address, CancellationToken cancellationToken = default);

        [Get("/maps/api/geocode/json")]
        Task<GeocodeResponse> GetGeocodeFromCoordinatesAsync(
            [Query] string latlng,
            [Query("location_type")] LocationTypeRequest locationTypeRequest = LocationTypeRequest.Rooftop,
            [Query("result_type")] ResultTypeRequest resultTypeRequest = ResultTypeRequest.Street_Address,
            CancellationToken cancellationToken = default);
    }
}