namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.ToDoItems.Queries
{
    using System;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.ToDoItems.Queries;
    using JordiAragonZaragoza.ToDos.Application.Mappers;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.Position;

    public static class ToDoItemsMapperExtension
    {
        public static void MapToDoItems(this Mapper maps)
        {
            maps.CreateMap<ToDoItemId, Guid>()
                .ConvertUsing(src => src.Value);

            maps.CreateMap<ToDoItem, ToDoItemOutputDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

            maps.CreateMap<ToDoItem, ToDoItemDetailsOutputDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

            maps.CreateMap<Location, LocationOutputDto>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Coordinates.Latitude.Value))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Coordinates.Longitude.Value))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(dest => dest.RegionCode, opt => opt.MapFrom(src => src.RegionCode))
                .ForMember(dest => dest.Locality, opt => opt.MapFrom(src => src.Locality))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
        }
    }
}