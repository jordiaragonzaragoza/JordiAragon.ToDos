namespace JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps
{
    using System.Linq;
    using JordiAragon.SharedKernel.Helpers;
    using JordiAragon.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Requests;
    using JordiAragon.ToDos.Infrastructure.Geolocation.GoogleMaps.Geocode.Responses;
    using JordiAragon.ToDos.Infrastructure.Mappers;

    public static class GoogleMapsMapperExtension
    {
        public static void MapGeolocation(this Mapper maps)
        {
            maps.CreateMap<GeocodeResponse, GeocodeOutputDto>()
                .ForMember(outputDto => outputDto.Latitude, option => option.MapFrom(g => g.Results.FirstOrDefault().Geometry.Location.Latitude))
                .ForMember(outputDto => outputDto.Longitude, option => option.MapFrom(g => g.Results.FirstOrDefault().Geometry.Location.Longitude))
                .ForMember(outputDto => outputDto.Address, option => option.MapFrom(g => g.Results.FirstOrDefault().FormattedAddress))
                .ForMember(outputDto => outputDto.CountryCode, option => option.MapFrom(g => g.Results.FirstOrDefault().AddressComponents.FirstOrDefault(i => i.Types.Contains(EnumHelper.GetEnumMemberValue(ResultTypeRequest.Country))).ShortName))
                .ForMember(outputDto => outputDto.RegionCode, option => option.MapFrom(g => g.Results.FirstOrDefault().AddressComponents.FirstOrDefault(i => i.Types.Contains(EnumHelper.GetEnumMemberValue(ResultTypeRequest.Administrative_Area_Level_1))).ShortName))
                .ForMember(outputDto => outputDto.Locality, option => option.MapFrom(g => g.Results.FirstOrDefault().AddressComponents.FirstOrDefault(i => i.Types.Contains(EnumHelper.GetEnumMemberValue(ResultTypeRequest.Locality))).LongName))
                .ForMember(outputDto => outputDto.PostalCode, option => option.MapFrom(g => g.Results.FirstOrDefault().AddressComponents.FirstOrDefault(i => i.Types.Contains(EnumHelper.GetEnumMemberValue(ResultTypeRequest.Postal_Code))).ShortName));
        }
    }
}