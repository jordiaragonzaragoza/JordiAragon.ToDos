namespace JordiAragonZaragoza.ToDos.Application.Features.Contributors.Queries
{
    using System;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragonZaragoza.ToDos.Application.Mappers;
    using JordiAragonZaragoza.ToDos.Domain.ContributorAggregate;

    public static class ContributorsMapperExtension
    {
        public static void MapContributors(this Mapper maps)
        {
            maps.CreateMap<ContributorId, Guid>()
                .ConvertUsing(src => src.Value);

            maps.CreateMap<Contributor, ContributorOutputDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
        }
    }
}