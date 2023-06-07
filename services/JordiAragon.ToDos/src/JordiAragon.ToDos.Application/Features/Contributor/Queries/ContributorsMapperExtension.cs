namespace JordiAragon.ToDos.Application.Features.Contributors.Queries
{
    using System;
    using JordiAragon.ToDos.Application.Contracts.Features.Contributors.Queries;
    using JordiAragon.ToDos.Application.Mappers;
    using JordiAragon.ToDos.Domain.ContributorAggregate;

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