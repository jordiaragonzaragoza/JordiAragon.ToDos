namespace JordiAragonZaragoza.ToDos.Application.Features.Projects.Queries
{
    using System;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragonZaragoza.ToDos.Application.Mappers;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate;
    using JordiAragonZaragoza.ToDos.Domain.ProjectAggregate.ColorModels;

    public static class ProjectsMapperExtension
    {
        public static void MapProjects(this Mapper maps)
        {
            maps.CreateMap<ProjectId, Guid>()
                .ConvertUsing(src => src.Value);

            maps.CreateMap<Project, ProjectOutputDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

            maps.CreateMap<Project, ProjectDetailsOutputDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

            maps.CreateMap<Priority, PriorityOutputDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            maps.CreateMap<Color, ColorOutputDto>()
                .ForMember(dest => dest.R, opt => opt.MapFrom(src => src.R.Value))
                .ForMember(dest => dest.G, opt => opt.MapFrom(src => src.G.Value))
                .ForMember(dest => dest.B, opt => opt.MapFrom(src => src.B.Value));
        }
    }
}