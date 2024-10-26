namespace JordiAragonZaragoza.ToDos.Infrastructure.Geolocation.GoogleMaps
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Ardalis.Result;
    using AutoMapper;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Interfaces;

    public class GoogleMapsGeolocationService : IGeolocationService
    {
        private readonly IGoogleMapsWebApi googleMapsWebApi;
        private readonly IMapper mapper;

        public GoogleMapsGeolocationService(
            IGoogleMapsWebApi googleMapsWebApi,
            IMapper mapper)
        {
            this.googleMapsWebApi = googleMapsWebApi ?? throw new ArgumentNullException(nameof(googleMapsWebApi));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<GeocodeOutputDto>> GetGeocodeAsync(string addressSearch, CancellationToken cancellationToken = default)
        {
            var geocodeResponse = await this.googleMapsWebApi.GetGeocodeFromAddressAsync(addressSearch, cancellationToken); // TODO: Add API Manager with polly.

            return Result.Success(this.mapper.Map<GeocodeOutputDto>(geocodeResponse));
        }

        public async Task<Result<GeocodeOutputDto>> GetGeocodeAsync(float latitude, float longitude, CancellationToken cancellationToken = default)
        {
            var latlng = $"{latitude.ToString("F6")},{longitude.ToString("F6")}";

            var reverseGeocodeResponse = await this.googleMapsWebApi.GetGeocodeFromCoordinatesAsync(latlng, cancellationToken: cancellationToken); // TODO: Add API Manager with polly.

            return Result.Success(this.mapper.Map<GeocodeOutputDto>(reverseGeocodeResponse));
        }
    }
}