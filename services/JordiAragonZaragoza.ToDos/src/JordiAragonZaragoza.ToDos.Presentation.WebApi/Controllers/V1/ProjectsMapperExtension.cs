namespace JordiAragonZaragoza.ToDos.Presentation.WebApi.Controllers.V1
{
    using System.Collections.Generic;
    using Ardalis.Result;
    using JordiAragon.SharedKernel.Application.Contracts;
    using JordiAragon.SharedKernel.Presentation.WebApi.Contracts;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Commands;
    using JordiAragonZaragoza.ToDos.Application.Contracts.Features.Projects.Queries;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.Requests;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Contracts.V1.Projects.Responses;
    using JordiAragonZaragoza.ToDos.Presentation.WebApi.Mappers.V1;

    public static class ProjectsMapperExtension
    {
        public static void MapProject(this Mapper maps)
        {
            // Requests to queries or commands.
            maps.CreateMap<GetProjectsPaginatedRequest, GetProjectsPaginatedQuery>();
            maps.CreateMap<CreateProjectRequest, CreateProjectCommand>();
            maps.CreateMap<UpdateProjectRequest, UpdateProjectCommand>();
            maps.CreateMap<UpdateProjectDetailsRequest, UpdateProjectDetailsCommand>();
            maps.CreateMap<PriorityRequest, PriorityInputDto>();
            maps.CreateMap<ColorRequest, ColorInputDto>();

            // OutputDtos to responses.
            maps.CreateMap<ProjectOutputDto, ProjectResponse>();
            maps.CreateMap<ProjectDetailsOutputDto, ProjectDetailsResponse>();
            maps.CreateMap<PriorityOutputDto, PriorityResponse>();
            maps.CreateMap<ColorOutputDto, ColorResponse>();
            maps.CreateMap<Result<ProjectOutputDto>, Result<ProjectResponse>>();
            maps.CreateMap<Result<ProjectDetailsOutputDto>, Result<ProjectDetailsResponse>>();
            maps.CreateMap<Result<IEnumerable<ProjectOutputDto>>, Result<IEnumerable<ProjectResponse>>>();
            maps.CreateMap<FileOutputDto, FileResponse>(); // TODO: Move to common mapping.
            maps.CreateMap<Result<FileOutputDto>, Result<FileResponse>>(); // TODO: Move to common mapping.
            maps.CreateMap<PaginatedCollectionOutputDto<ProjectOutputDto>, PaginatedCollectionResponse<ProjectResponse>>();
            maps.CreateMap<Result<PaginatedCollectionOutputDto<ProjectOutputDto>>, Result<PaginatedCollectionResponse<ProjectResponse>>>();
        }
    }
}